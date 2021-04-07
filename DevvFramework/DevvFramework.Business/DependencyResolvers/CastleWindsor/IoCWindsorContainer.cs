using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DevvFramework.Business.Abstract;
using DevvFramework.Business.Concrete.Managers;
using DevvFramework.Core.DataAccess.Nhibernate;
using DevvFramework.DataAccess.Abstract;
using DevvFramework.DataAccess.Concrete.EntityFramework;
using DevvFramework.DataAccess.Concrete.Nhibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Business.DependencyResolvers.CastleWindsor
{
    public static class IoCWindsorContainer
    {
        private static IWindsorContainer _container = null;
        private static IWindsorContainer Container
        {
            get { return _container ?? (_container = BusinessModule()); }
        }
        private static IWindsorContainer BusinessModule()
        {
            return new WindsorContainer()
                .Register(
                Component.For<IProductService>().ImplementedBy<ProductManager>()
                , Component.For<IProductDal>().ImplementedBy<EfProductDal>()
                , Component.For<NhibernateHelper>().ImplementedBy<SqlServerHelper>());
        }
        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
