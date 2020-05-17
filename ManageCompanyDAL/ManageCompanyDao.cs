using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDAL;
using DBUtils;
using Entities;

namespace ManageCompanyDAL
{
    public class ManageCompanyDao : IDao<ManageCompany>
    {
        public IEnumerable<ManageCompany> GetAll()
        {
            var result = new List<ManageCompany>();
            using (var connection = MssqlCon.GetDbConnection())
            {
                const string sql = "select id_name, fsl_owner, office_address, count_house from manage_company";
                var cmd = new SqlCommand(sql, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idName = (string) reader["id_name"];
                    var fslOwner = (string) reader["fsl_owner"];
                    var officeAddress = (string) reader["office_address"];
                    var countHouse = (int) reader["count_house"];
                    var temp = new ManageCompany(idName, fslOwner, officeAddress, countHouse);
                    result.Add(temp);
                }
            }

            return result;
        }

        public int Add(ManageCompany T)
        {
            using (var connection = MssqlCon.GetDbConnection())
            {
                try
                {
                    connection.Open();
                    const string sql = "INSERT INTO manage_company Values (@id_name, @fsl_owner, @office_address, @count_house);";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id_name", T.IdName);
                    cmd.Parameters.AddWithValue("@fsl_owner", T.FslOwner);
                    cmd.Parameters.AddWithValue("@office_address", T.OfficeAddress);
                    cmd.Parameters.AddWithValue("@count_house", T.CountHouse);
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
                    const string sql = "delete from manage_company where id_name = @id";
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