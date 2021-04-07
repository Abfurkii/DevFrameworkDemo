using DevvFramework.Business.Abstract;
using DevvFramework.Business.ValidationRules.FluentValidation;
using DevvFramework.Core.CrossCuttingConcerns.Validation;
using DevvFramework.DataAccess.Abstract;
using DevvFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevvFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevvFramework.Core.Aspects.PostSharp.TransactionAspects;
using DevvFramework.Core.Aspects.PostSharp.CacheAspects;
using DevvFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevvFramework.Core.Aspects.PostSharp.LogAspects;
using DevvFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace DevvFramework.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        [FluentValidationAspects(typeof(ProductValidation))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }
       
        [CacheAspect(typeof(MemoryCacheManager),60)]
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
