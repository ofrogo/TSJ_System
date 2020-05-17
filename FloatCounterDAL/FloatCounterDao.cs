using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace FloatCounterDAL
{
    public class FloatCounterDao : IDao<FloatCounter>
    {
        public IEnumerable<FloatCounter> GetAll()
        {
            var result = new List<FloatCounter>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id_owner, water, gas, electricity from float_counter";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idOwner = (string) reader["id_owner"];
                    var water = (int) reader["water"];
                    var gas = (int) reader["gas"];
                    var electricity = (int) reader["electricity"];
                    var temp = new FloatCounter(idOwner, water, gas, electricity);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(FloatCounter T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO float_counter Values (@id_owner, @water, @gas, @electricity);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_owner", T.IdOwner);
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
                    const string sql = "delete from float_counter where id_owner = @id";
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