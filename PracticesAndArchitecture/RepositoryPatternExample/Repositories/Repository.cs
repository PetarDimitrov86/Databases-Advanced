using System;
using System.Collections.Generic;
using System.Linq;
using PhotoShare.Client.IO;
using PhotoShare.Data;
using System.Linq.Expressions;

namespace PhotoShare.Client.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PhotoShareContext Context;

        public Repository()
        {
            this.Context = new PhotoShareContext();
        }

        public Repository(PhotoShareContext context)
        {
            this.Context = context;
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }       

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                    this.Delete(entity);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }
    }
}