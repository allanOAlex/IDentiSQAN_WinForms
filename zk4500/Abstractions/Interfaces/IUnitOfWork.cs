using System.Threading.Tasks;
using zk4500.Abstractions.IRepositories;

namespace zk4500.Abstractions.Interfaces
{
    public interface IUnitOfWork
    {
        IFingerPrintRepository FingerPrintRepository { get; }
        IPatientRepository PatientRepository { get; }

        Task CompleteAsync();

    }
}
