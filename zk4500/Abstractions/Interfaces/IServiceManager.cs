using zk4500.Abstractions.IServices;

namespace zk4500.Abstractions.Interfaces
{
    public interface IServiceManager
    {
        IFingerPrintService FingerPrintService { get; }
        IPatientService PatientService { get; }
        IUserService UserService { get; }


    }
}
