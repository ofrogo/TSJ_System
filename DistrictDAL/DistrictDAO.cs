using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace DistrictDAL
{
    public class DistrictDao : IDistrictDao
    {
        

        public IEnumerable<District> GetAll()
        {
            var result = new List<District>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id_name from district";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var temp = new District((string) reader["id_name"]);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Delete(string id)
        {
            try
            {
                using (var connection = MssqlCon.GetDbConnection())
                {
                    const string sql = "delete from district where id_name = @id";
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

        public int Add(District district)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO district Values (@name);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@name", district.IdName);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return -1;
                }
            }

        }
    }
}