using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesRepository.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(int Id);
        IQueryable<T> Get();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
