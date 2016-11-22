using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhotoShare.Client.IO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity GetById(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}