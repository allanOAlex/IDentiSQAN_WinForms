using System.Threading.Tasks;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;

namespace zk4500.ApiClient
{
    public interface IAuthApiClient
    {
        Task InvokeHMIS(LoginRequest loginRequest);
        Task<ApiResponse<bool>> NotifyVerified(LoginRequest loginRequest);
        Task CallApiWithEncodedQueryParams(LoginRequest loginRequest);
        Task CallApiWithNonEncodedQueryParams(LoginRequest loginRequest);
        


    }
}
