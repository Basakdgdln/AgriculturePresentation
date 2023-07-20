using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class SaleValidator: AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x=>x.ProductID).NotEmpty().WithMessage("Ürün alanı boş geçilemez..");
            RuleFor(x=>x.Piece).NotEmpty().WithMessage("Adet boş geçilemez..");
            RuleFor(x=>x.TotalAmount).NotEmpty().WithMessage("Toplam tutar boş geçilemez..");
        }
    }
}
