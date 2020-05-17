using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace TsjServiceDAL
{
    public class TsjServiceDao : IDao<TsjService>
    {
        public IEnumerable<TsjService> GetAll()
        {
            var result = new List<TsjService>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id_name, price from tsj_service";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idName = (string) reader["id_name"];
                    var price = (int) reader["price"];
                    var temp = new TsjService(idName, price);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(TsjService T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO tsj_service Values (@id_name, @price);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_name", T.IdName);
                    cmd.Parameters.AddWithValue("@price", T.Price);
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
                    const string sql = "delete from tsj_service where id_name = @id";
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