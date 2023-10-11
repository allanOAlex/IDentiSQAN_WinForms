using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zk4500.Abstractions.IServices
{
    public interface IConfigurationService
    {
        Task<string> GetConnectionString(string name);
        Task<string> GetString(string name);
        Task<string> GetApiBaseUrl();
        Task<string> GetApiEndpointUrl(string endpointKey);
    }
}
