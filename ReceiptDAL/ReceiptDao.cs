using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace ReceiptDAL
{
    public class ReceiptDao : IDao<Receipt>
    {
        public IEnumerable<Receipt> GetAll()
        {
            var result = new List<Receipt>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id, id_bill, bill_date, amount, debt, balance from receipt";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int) reader["id"];
                    var idBill = (string) reader["id_bill"];
                    var billDate = (DateTime) reader["bill_date"];
                    var amount = (int) reader["amount"];
                    var debt = (int) reader["debt"];
                    var balance = (int) reader["balance"];
                    var temp = new Receipt(id, idBill, billDate, amount, debt, balance);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(Receipt T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO receipt Values (@id_bill, @bill_date, @amount, @debt, @balance);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_bill", T.IdBill);
                    cmd.Parameters.AddWithValue("@bill_date", T.BillDate);
                    cmd.Parameters.AddWithValue("@amount", T.Amount);
                    cmd.Parameters.AddWithValue("@debt", T.Debt);
                    cmd.Parameters.AddWithValue("@balance", T.Balance);
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
                    const string sql = "delete from receipt where id = @id";
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