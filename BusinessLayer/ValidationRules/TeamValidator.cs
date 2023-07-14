using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım üyesi adını boş geçemezsiniz...");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev alanını boş geçemezsiniz...");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim alanını boş geçemezsiniz...");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapınız... ");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız... ");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapınız... ");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 3 karakter veri girişi yapınız...  ");
        }
    }
}
