namespace Photography.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(ICollection<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(ICollection<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault();

        TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate);
    }
}