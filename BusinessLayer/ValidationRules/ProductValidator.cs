using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı alanı boş geçilemez...");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Kategori alanı boş geçilemez...");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Ürün stok değeri boş geçilemez...");
        }
    }
}
