using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Samples.NServiceBus.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetQueryable();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}