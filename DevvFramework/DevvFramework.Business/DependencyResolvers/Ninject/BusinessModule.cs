using DevvFramework.Business.Abstract;
using DevvFramework.Business.Concrete.Managers;
using DevvFramework.Core.DataAccess.Nhibernate;
using DevvFramework.DataAccess.Abstract;
using DevvFramework.DataAccess.Concrete.EntityFramework;
using DevvFramework.DataAccess.Concrete.Nhibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();
            Bind<NhibernateHelper>().To<SqlServerHelper>().InSingletonScope();
        }
    }
}
