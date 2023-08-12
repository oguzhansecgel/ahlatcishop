using Ahlatci.Shop.Application.Models.RequestModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductVM>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.ProductID)
                .NotNull().WithMessage("Silinecek ürünün kimlik numarası boş bırakılamaz")
                .GreaterThan(0).WithMessage("Idsi 0 dan büyük olmalıdır.");
        }
    }
}
