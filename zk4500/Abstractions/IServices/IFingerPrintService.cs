using System.Collections.Generic;
using System.Threading.Tasks;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Abstractions.IServices
{
    public interface IFingerPrintService
    {
        Task<RegisterFingerPrintResponse> Create(RegisterFingerPrintRequest registerFingerPrintRequest);
        Task<RegisterFingerPrintResponse> SQLCreate(RegisterFingerPrintRequest registerFingerPrintRequest);
        Task<List<FetchFingerPrintResponse>> FindAll();
        Task<List<FetchFingerPrintResponse>> SQLFindAll();
        Task<List<FetchPatientForVerificationResponse>> SQLFetchPatientsForVerification();
        Task<FetchFingerPrintResponse> GetById(int Id);
        Task<UpdateFingerPrintResponse> Update(UpdateFingerPrintRequest updateFingerPrintRequest);
        Task<UpdateFingerPrintResponse> Delete(UpdateFingerPrintRequest updateFingerPrintRequest);
        Task<VerifyFingerPrintResponse> Verify(VerifyFingerPrintRequest verifyFingerPrintRequest);
        void InitializeFingerprintEngine();


    }
}
