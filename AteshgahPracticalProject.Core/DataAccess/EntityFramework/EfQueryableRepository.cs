using AteshgahPracticalProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<TEntity> : IQueryableRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private IDbSet<TEntity> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Table => this.Entities;

        protected IDbSet<TEntity> Entities 
        {
            get
            {
                return _entities ?? _context.Set<TEntity>();
            }
        }
    }
}
