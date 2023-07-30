using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryViewModel>
    {
        public UpdateCategoryValidator()
        {

            RuleFor(x => x.Id)
                   .NotEmpty()
                   .WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                   .GreaterThan(0)
                   .WithMessage("Kategori kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CatergoryName)
                .NotEmpty()
                .WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Kategori adı 100 karakterden fazla olamaz.");
        }
    }
}
