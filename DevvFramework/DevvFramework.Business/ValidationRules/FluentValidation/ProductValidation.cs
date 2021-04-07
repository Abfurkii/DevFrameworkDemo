using DevvFramework.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Business.ValidationRules.FluentValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz!");
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Birim fiyatı boş bırakılamaz!");
            RuleFor(x => x.UnitsInStock).NotEmpty();
            RuleFor(x => x.ProductName).Length(2, 20);
            RuleFor(x => x.UnitPrice).GreaterThan(20).When(x => x.UnitPrice == 1);
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Birim fiyatı sıfırdan büyük olmalıdır!");
        }
    }
}
