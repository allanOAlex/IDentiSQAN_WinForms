using MySql.Data.MySqlClient;
using System.Data;
using zk4500.Abstractions.IServices;

namespace zk4500.DataContext
{
    public class DapperContext
    {
        private readonly IConfigurationService configuration;
        private readonly string connectionString;

        public DapperContext(IConfigurationService Configuration)
        {
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Promed").ToString();
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(connectionString);
    }
}
