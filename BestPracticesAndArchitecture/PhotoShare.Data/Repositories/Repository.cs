namespace PhotoShare.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Interfaces;
    using System.Data.Entity;
    using EntityFramework.Extensions;
    using System.Linq;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> set;

        public Repository(DbSet<TEntity> set)
        {
            this.set = set;
        }
        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            this.set.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void DeleteRange(ICollection<TEntity> entities)
        {
            this.set.Delete(entities.AsQueryable());
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.set;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public TEntity FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.FirstOrDefault(predicate);
        }
    }
}