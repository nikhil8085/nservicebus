using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Samples.NServiceBus.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IDataContext dataContext;

        public Repository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return Queryable.AsQueryable<TEntity>(dataContext.Set<TEntity>());
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return GetQueryable()
                .FirstOrDefault(p => p.Id == id);
        }

        public virtual IQueryable<TEntity> GetQueryable(params Expression<Func<TEntity, object>>[] eagerLoadProperties)
        {
            var query = GetQueryable();

            foreach (var property in eagerLoadProperties)
            {
                query = query.Include(property);
            }
            return query;
        }

        public virtual void Insert(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dataContext.Set<TEntity>().Remove(entity);
        }

        public virtual void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}
