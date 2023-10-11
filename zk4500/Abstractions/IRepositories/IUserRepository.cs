using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Entities;

namespace zk4500.Abstractions.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IQueryable<User>> SQLFetchPatientsForVerification();
        Task<IQueryable<User>> SQLFindByLoginCredentials(); 
        Task<User> SQLUpdateVerified(User entity);

    }
}
