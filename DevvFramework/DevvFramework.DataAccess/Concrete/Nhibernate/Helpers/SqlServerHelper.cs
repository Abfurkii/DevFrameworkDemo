using DevvFramework.Core.DataAccess.Nhibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.DataAccess.Concrete.Nhibernate.Helpers
{
    public class SqlServerHelper : NhibernateHelper
    {
        public override ISessionFactory Initialize()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(x => x.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
