using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Abstractions.IServices
{
    public interface IUserService
    {
        Task<List<FetchUserResponse>> SQLFindAll();
        Task<ApiResponse<FetchUserResponse>> SQLFindByCondition(FetchUserRequest fetchUserRequest);
        Task<ApiResponse<FetchUserResponse>> SQLFindByLoginCredentials(FetchUserRequest fetchUserRequest);
        Task<UpdateVerifiedResponse> SQLUpdateVerified(UpdateVerifiedRequest updateVerifiedRequest);


    }
}
