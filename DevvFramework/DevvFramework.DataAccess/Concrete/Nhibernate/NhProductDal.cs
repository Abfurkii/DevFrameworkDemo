using DevvFramework.Core.DataAccess.Nhibernate;
using DevvFramework.DataAccess.Abstract;
using DevvFramework.Entities.ComplexTypes;
using DevvFramework.Entities.Concrete;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.DataAccess.Concrete.Nhibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>,IProductDal
    {
        private NhibernateHelper _nhibernateHelper;
        public NhProductDal(NhibernateHelper nhibernateHelper):base(nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session=_nhibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.Id
                             select new ProductDetail
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
