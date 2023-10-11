using System.Collections.Generic;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Abstractions.IServices
{
    public interface IPatientService
    {
        Task<List<FetchPatientResponse>> FindAll();
        Task<List<FetchPatientResponse>> SQLFindAll();
        Task<FetchPatientResponse> GetById(int Id);
        Task<ApiResponse<FetchPatientResponse>> FindByCondition(FetchPatientRequest fetchPatientRequest);
        Task<ApiResponse<FetchPatientResponse>> SQLFindByCondition(FetchPatientRequest fetchPatientRequest);
        Task<List<FetchPatientForVerificationResponse>> SQLFetchPatientsForVerification();
        Task<UpdateVerifiedResponse> SQLUpdateVerified(UpdateVerifiedRequest updateVerifiedRequest);
        Task<UpdatePatientResponse> Update(UpdatePatientRequest updatePatientRquest); 


    }
}
