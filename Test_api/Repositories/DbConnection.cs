using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Test_api.Repositories
{
    public class DbConnection : IDbConnection
    {
        public NpgsqlConnection Connection { get; }
        public string ConnectionString
        {
            get { return Connection.ConnectionString; }
            set { Connection.ConnectionString = value; }
        }

        public int ConnectionTimeout => Connection.ConnectionTimeout;

        public string Database => Connection.Database;

        public ConnectionState State => Connection.State;

        public DbConnection(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("dbConnection"));
        }

        public IDbTransaction BeginTransaction() => Connection.BeginTransaction();

        public IDbTransaction BeginTransaction(IsolationLevel il) => Connection.BeginTransaction(il);
        public void ChangeDatabase(string databaseName) => Connection.ChangeDatabase(databaseName);
        public void Close() => Connection.Close();

        public IDbCommand CreateCommand() => Connection.CreateCommand();

        public void Open() => Connection.Open();

        public void Dispose() => Connection.Dispose();
    }
}
