using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IServices;
using zk4500.Implementations.Services;

namespace zk4500.Implementations.Interfaces
{
    internal sealed class ServiceManager : IServiceManager
    {
        public IFingerPrintService FingerPrintService { get; private set; }
        public IPatientService PatientService { get; private set; }

        private readonly IUnitOfWork unitOfWork;

        public ServiceManager(UnitOfWork UnitOfWork)
        {

            unitOfWork = UnitOfWork;
            FingerPrintService = new FingerPrintService(unitOfWork);
            PatientService = new PatientService(unitOfWork);
        }

        
    }
}
