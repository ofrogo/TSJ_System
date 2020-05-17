using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace BillDAL
{
    public class BillDao : IDao<Bill>
    {
        public IEnumerable<Bill> GetAll()
        {
            var result = new List<Bill>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id, id_company, id_jilez from bill";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (string) reader["id"];
                    var idCompany = (string) reader["id_company"];
                    var idJilez = (string) reader["id_jilez"];
                    var temp = new Bill(id, idCompany, idJilez);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(Bill T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO bill Values (@id, @id_company, @id_jilez);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", T.Id);
                    cmd.Parameters.AddWithValue("@id_company", T.IdCompany);
                    cmd.Parameters.AddWithValue("@id_jilez", T.IdJilez);
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
                    const string sql = "delete from bill where id = @id";
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