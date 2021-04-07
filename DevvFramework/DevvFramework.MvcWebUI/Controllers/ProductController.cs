using DevvFramework.Business.Abstract;
using DevvFramework.Entities.Concrete;
using DevvFramework.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevvFramework.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Product = _productService.GetAll()
            };
            return View(model);
        }
        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "AsusMyPhone",
                QuantityPerUnit = "1",
                UnitsInStock = 1,
                UnitPrice = 18
            });
            return "Added";
        }
        public void AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Something1",
                QuantityPerUnit = "1",
                UnitPrice=12,
                UnitsInStock=1
            },new Product
            {
                CategoryId=1,
                ProductName="Something2",
                QuantityPerUnit="1",
                UnitPrice=8,
                UnitsInStock=1,
                Id=2
            });
        }
    }
}