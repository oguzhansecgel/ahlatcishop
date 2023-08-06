using Ahlatci.Shop.Application.Models.RequestModels.Cities;
using Ahlatci.Shop.Domain.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Cities
{
	public class UpdateCityValidator : AbstractValidator<UpdateCityVM>
	{
        public UpdateCityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Şehir kimlik numarası boş olamaz..!")
                .GreaterThan(0).WithMessage("Şehir kimlik numarası 0 dan büyük bir sayı olmalıdır.");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Şehir Adı Boş Olamaz")
                .MaximumLength(20).WithMessage("Şehir adı 20 karakterden büyük olamaz");
        }
    }
}
