using DevvFramework.Core.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.DataAccess.Nhibernate
{
    public class NhQueryableRepositoryBase<TEntity> : IQueryableRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private NhibernateHelper _nhibernateHelper;
        private IQueryable<TEntity> _entities;
        public NhQueryableRepositoryBase(NhibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }
        public IQueryable<TEntity> Table => this.Entities;
        public IQueryable<TEntity> Entities
        {
            get { return _entities ?? (_nhibernateHelper.OpenSession().Query<TEntity>()); }
        }
    }
}
