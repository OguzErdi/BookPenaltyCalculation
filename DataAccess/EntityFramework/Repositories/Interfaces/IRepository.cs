using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}