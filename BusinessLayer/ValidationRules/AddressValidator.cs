using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Adres boş geçilemez...");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Podta kodu - şehir boş geçilemez...");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Mail adresi boş geçilemez...");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Telefon numarası boş geçilemez...");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez...");
            RuleFor(x => x.Description1).MaximumLength(100).WithMessage("Lütfen açıklamayı kısaltın...");
            RuleFor(x => x.Description2).MaximumLength(50).WithMessage("Lütfen açıklamayı kısaltın...");
            RuleFor(x => x.Description3).MaximumLength(25).WithMessage("Lütfen açıklamayı kısaltın...");
            RuleFor(x => x.Description4).MaximumLength(25).WithMessage("Lütfen açıklamayı kısaltın...");
            
        }
    }
}
  