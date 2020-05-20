using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace JilezDAL
{
    public class JilezDao : IDao<Jilez>
    {
        public Jilez GetById(string id)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql =
                    "select fsl, passport_id, number_flat, house_address from jilez where passport_id=@id";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();

                var fsl = (string) reader["fsl"];
                var passportId = (string) reader["passport_id"];
                var numberFlat = (int) reader["number_flat"];
                var houseAddress = (string) reader["house_address"];
                return new Jilez(passportId, fsl, numberFlat, houseAddress);
            }
        }

        public IEnumerable<Jilez> GetAll()
        {
            var result = new List<Jilez>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select fsl, passport_id, number_flat, house_address from jilez";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var fsl = (string) reader["fsl"];
                    var passportId = (string) reader["passport_id"];
                    var numberFlat = (int) reader["number_flat"];
                    var houseAddress = (string) reader["house_address"];
                    var temp = new Jilez(passportId, fsl, numberFlat, houseAddress);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(Jilez T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO jilez Values (@fsl, @passport_id, @number_flat, @house_address);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@fsl", T.Fsl);
                    cmd.Parameters.AddWithValue("@passport_id", T.PassportId);
                    cmd.Parameters.AddWithValue("@number_flat", T.NumberFlat);
                    cmd.Parameters.AddWithValue("@house_address", T.HouseAddress);
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
                    const string sql = "execute safe_delete_jilez @passport_id = @id";
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