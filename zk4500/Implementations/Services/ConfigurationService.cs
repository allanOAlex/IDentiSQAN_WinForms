using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Abstractions.IServices;

namespace zk4500.Implementations.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public ConfigurationService()
        {
        }

        public async Task<string> GetConnectionString(string name)
        {
            try
            {
                return await Task.FromResult(ConfigurationManager.ConnectionStrings[name]?.ConnectionString);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetString(string name)
        {
            try
            {
                return await Task.FromResult(ConfigurationManager.AppSettings[name]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetApiBaseUrl()
        {
            try
            {
                return await Task.FromResult(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetApiEndpointUrl(string endpointKey)
        {
            try
            {
                return await Task.FromResult(ConfigurationManager.AppSettings[endpointKey]);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
