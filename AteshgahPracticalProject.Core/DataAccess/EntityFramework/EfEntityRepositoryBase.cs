using AteshgahPracticalProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            int changes = 0;
            TEntity result = null;

            using (var context = new TContext())
            {
                var systemEntity = context.Entry(entity);
                systemEntity.State = EntityState.Added;
                changes = context.SaveChanges();
            }

            if (changes > 0) result = entity;

            return result;
        }

        public TEntity Delete(TEntity entity)
        {
            int changes = 0;
            TEntity result = null;

            using (var context = new TContext())
            {
                var systemEntity = context.Entry(entity);
                systemEntity.State = EntityState.Deleted;
                changes = context.SaveChanges();
            }

            if (changes > 0) result = entity;

            return result;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            int changes = 0;
            TEntity result = null;

            using (var context = new TContext())
            {
                var systemEntity = context.Entry(entity);
                systemEntity.State = EntityState.Modified;
                changes = context.SaveChanges();
            }

            if (changes > 0) result = entity;

            return result;
        }
    }
}
