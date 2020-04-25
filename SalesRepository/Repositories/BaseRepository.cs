using SalesRepository.Context;
using SalesRepository.Entities;
using SalesRepository.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesRepository.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected RepositoryContext _repositoryContext { get; set; }

        public BaseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }


        public Task<TEntity> GetById(int Id)
        {
            return Get().Where(p => p.Id == Id)
                 .FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> Get()
        {
            return _repositoryContext.Set<TEntity>();
        }


        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _repositoryContext.Set<TEntity>().Where(expression);
        }

        public void Create(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().AddOrUpdate(entity);
            _repositoryContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Remove(entity);
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

    }
}
