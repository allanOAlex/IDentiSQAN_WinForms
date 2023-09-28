using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zk4500.Abstractions.IRepositories;

namespace zk4500.Implementations.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository()
        {

        }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> SQLCreate(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> SQLDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> SQLFindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> SQLFindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> SQLFindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> SQLUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
