using DevvFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product Get(Expression<Func<Product, bool>> filter);
        Product Add(Product product);
        Product Update(Product product);
        void Delete(Product product);
        void TransactionalOperation(Product product1, Product product2);
    }
}
