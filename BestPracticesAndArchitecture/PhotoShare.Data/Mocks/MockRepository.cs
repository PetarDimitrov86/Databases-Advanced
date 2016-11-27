using System.Linq;

namespace PhotoShare.Data.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Interfaces;


    public class MockRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private List<TEntity> entities;

        public MockRepository()
        {
            this.entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            this.entities.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void DeleteRange(ICollection<TEntity> entitiesOut)
        {
            foreach (var entity in entitiesOut)
            {
                this.Delete(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.entities;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate.Compile());
        }

        public TEntity FirstOrDefault()
        {
            return this.entities.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.FirstOrDefault(predicate.Compile());
        }
    }
}