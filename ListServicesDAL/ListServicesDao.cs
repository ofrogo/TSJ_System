using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace ListServicesDAL
{
    public class ListServicesDao : IDao<ListServices>
    {
        public IEnumerable<ListServices> GetAll()
        {
            var result = new List<ListServices>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id, id_bill, id_service, amount from list_services";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int) reader["id"];
                    var idBill = (string) reader["id_bill"];
                    var idService = (string) reader["id_service"];
                    var amount = (int) reader["amount"];
                    var temp = new ListServices(id, idBill, idService, amount);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(ListServices T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO list_services Values (@id_bill, @id_services, @amount);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_bill", T.IdBill);
                    cmd.Parameters.AddWithValue("@id_services", T.IdService);
                    cmd.Parameters.AddWithValue("@amount", T.Amount);
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
                    const string sql = "delete from list_services where id = @id";
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