using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace HouseCounterDAL
{
    public class HouseCounterDao : IDao<HouseCounter>
    {
        public IEnumerable<HouseCounter> GetAll()
        {
            var result = new List<HouseCounter>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id, water, gas, electricity from house_counter";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idOwner = (string) reader["id"];
                    var water = (int) reader["water"];
                    var gas = (int) reader["gas"];
                    var electricity = (int) reader["electricity"];
                    var temp = new HouseCounter(idOwner, water, gas, electricity);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(HouseCounter T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO house_counter Values (@id_owner, @water, @gas, @electricity);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_owner", T.Id);
                    cmd.Parameters.AddWithValue("@water", T.Water);
                    cmd.Parameters.AddWithValue("@gas", T.Gas);
                    cmd.Parameters.AddWithValue("@electricity", T.Electricity);
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
                    const string sql = "delete from house_counter where id = @id";
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