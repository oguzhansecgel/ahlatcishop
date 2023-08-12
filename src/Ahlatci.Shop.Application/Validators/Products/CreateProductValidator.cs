using Ahlatci.Shop.Application.Models.RequestModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Products
{
	public class CreateProductValidator : AbstractValidator<CreateProductVM>
	{
        public CreateProductValidator()
        {
			RuleFor(x => x.Name)
			   .NotNull().WithMessage("Ürün Adı Boş Olamaz")
			   .MaximumLength(255).WithMessage("Ürün adı 255 karakterden büyük olamaz");
			RuleFor(x => x.Detail)
			   .NotNull().WithMessage("Ürün Detayı Boş Olamaz")
			   .MaximumLength(250).WithMessage("Ürün Detayı 250 karakterden büyük olamaz");
			RuleFor(x => x.UnitInStock)
			   .NotNull().WithMessage("Ürün Stok Boş Olamaz");
			RuleFor(x => x.UnitPrice)
			   .NotNull().WithMessage("Ürün Fiyat Bilgisi Boş Olamaz");

		}
    }
}
