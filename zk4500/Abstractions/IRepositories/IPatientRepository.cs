using System.Linq;
using System.Threading.Tasks;
using zk4500.Entities;

namespace zk4500.Abstractions.IRepositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerification();
        Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerificationByCondition();
        Task<Patient> SQLUpdateVerified(Patient entity);
    }
}
