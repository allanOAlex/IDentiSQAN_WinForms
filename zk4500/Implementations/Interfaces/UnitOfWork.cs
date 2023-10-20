using System;
using System.Threading.Tasks;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.DataContext;
using zk4500.Implementations.Repositories;

namespace zk4500.Implementations.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFingerPrintRepository FingerPrintRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        private readonly IConfigurationService configurationService;
        private readonly MyDBContext myContext;

        public UnitOfWork(MyDBContext MyContext, IConfigurationService ConfigurationService)
        {
            myContext = MyContext;
            configurationService = ConfigurationService;
            FingerPrintRepository = new FingerPrintRepository(myContext, configurationService);
            PatientRepository = new PatientRepository(myContext, configurationService);
            UserRepository = new UserRepository(configurationService);
        }

        public async Task CompleteAsync()
        {
            try
            {
                await myContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                myContext.Dispose();
            }
        }



    }
}
