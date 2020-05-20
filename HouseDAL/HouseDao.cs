using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace HouseDAL
{
    public class HouseDao : IDao<House>
    {
        public House GetById(string address)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                connection.Open();
                const string sql = "select id_address, count_podezd, count_floor, id_district, id_company from house where id_address = @address";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@address", address);
                
                var reader = cmd.ExecuteReader();
                reader.Read();

                var idAddress = (string) reader["id_address"];
                var countPodezd = (int) reader["count_podezd"];
                var countFLoor = (int) reader["count_floor"];
                var idDistrict = (string) reader["id_district"];
                var idCompany = (string) reader["id_company"];
                return new House(idAddress, countPodezd, countFLoor, idDistrict, idCompany);
            }
        }

        public IEnumerable<House> GetAll()
        {
            var result = new List<House>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id_address, count_podezd, count_floor, id_district, id_company from house";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idAddress = (string) reader["id_address"];
                    var countPodezd = (int) reader["count_podezd"];
                    var countFLoor = (int) reader["count_floor"];
                    var idDistrict = (string) reader["id_district"];
                    var idCompany = (string) reader["id_company"];
                    var temp = new House(idAddress, countPodezd, countFLoor, idDistrict, idCompany);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(House T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql =
                        "INSERT INTO house Values (@id_address, @count_podezd, @count_floor, @id_district, @id_company);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_address", T.IdAddress);
                    cmd.Parameters.AddWithValue("@count_podezd", T.CountPodezd);
                    cmd.Parameters.AddWithValue("@count_floor", T.CountFloor);
                    cmd.Parameters.AddWithValue("@id_district", T.IdDistrict);
                    cmd.Parameters.AddWithValue("@id_company", T.IdCompany);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return -1;
                }
            }
        }

        public int Delete(string id)
        {
            try
            {
                using (var connection = MssqlCon.GetDbConnection())
                {
                    const string sql = "delete from house where id_address = @id";
                    var cmd = new SqlCommand(sql, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}