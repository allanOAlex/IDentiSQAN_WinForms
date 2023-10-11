using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
