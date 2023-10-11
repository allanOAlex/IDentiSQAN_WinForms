using System.Linq;
using System.Threading.Tasks;
using zk4500.Entities;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Abstractions.IRepositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerification();
        Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerificationByCondition();
        Task<Patient> SQLUpdateVerified(Patient entity);
    }
}
