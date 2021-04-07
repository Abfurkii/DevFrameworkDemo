using DevvFramework.DataAccess.Concrete.Nhibernate;
using DevvFramework.DataAccess.Concrete.Nhibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevvFramework.DataAccess.Test.Nhibernate
{
    [TestClass]
    public class NhibernateTest
    {
        [TestMethod]
        public void Get_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetAll();

            Assert.AreEqual(88, result.Count);
        }
        [TestMethod]
        public void Get_with_parameters_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetAll(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(5, result.Count);
        }
    }
}
