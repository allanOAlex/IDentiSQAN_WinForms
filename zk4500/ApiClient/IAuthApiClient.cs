using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.ApiClient
{
    public interface IAuthApiClient
    {
        Task<ApiResponse<bool>> NotifyVerified(LoginRequest loginRequest);
        Task CallApi(LoginRequest loginRequest);
        Task ConsumeApi(LoginRequest loginRequest);
        Task InvokeApi(LoginRequest loginRequest);
        Task InvokeHMIS(LoginRequest loginRequest);
        //Task<bool> InvokeHMIS(LoginRequest loginRequest);
    }
}
