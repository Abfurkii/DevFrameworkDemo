using DevvFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepositoryBase<TEntity> : IQueryableRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<TEntity> _entities;
        public EfQueryableRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Table => this.Entities;
        protected virtual IDbSet<TEntity> Entities
        {
            get
            {
                return _entities ?? (_entities = _context.Set<TEntity>());
            }
        }
    }
}
