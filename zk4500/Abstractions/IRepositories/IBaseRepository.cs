using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zk4500.Entities;

namespace zk4500.Abstractions.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> FindAll();
        Task<IQueryable<T>> SQLFindAll();
        Task<T> FindById(int Id);
        Task<T> SQLFindById(int Id);
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> SQLFindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task<T> SQLCreate(T entity);
        Task<T> Update(T entity);
        Task<T> SQLUpdate(T entity);
        Task<T> Delete(T entity);
        Task<T> SQLDelete(T entity);


    }
}
