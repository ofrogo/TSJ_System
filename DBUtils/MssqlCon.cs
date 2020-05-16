using System;
using System.Data.SqlClient;

namespace DBUtils
{
    public static class MssqlCon
    {
        private static string _connectionString;

        private static void Build(string dataSource, string db)
        {
            _connectionString = $"Data Source={dataSource};Initial Catalog={db};Integrated Security=True";
        }

        public static SqlConnection GetDbConnection()
        {
            const string dataSource = "127.0.0.1";
            const string dbName = "oplata_tsj";
            if (_connectionString is null)
            {
                Build(dataSource, dbName);
            }
            return new SqlConnection(_connectionString ?? throw new Exception("Can't connect to db: Problem with connection string :("));
        }
    }
}