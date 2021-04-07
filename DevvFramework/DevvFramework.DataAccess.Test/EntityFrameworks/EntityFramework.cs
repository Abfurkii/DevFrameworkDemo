using DevvFramework.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevvFramework.DataAccess.Test.EntityFrameworks
{
    [TestClass]
    public class EntityFramework
    {
        [TestMethod]
        public void Get_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll();

            Assert.AreEqual(88, result.Count);
        }
        [TestMethod]
        public void Get_with_parameters_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(5, result.Count);
        }
    }
}
