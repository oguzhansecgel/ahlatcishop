using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.ProductImages
{
    public class DeleteProductImageValidator : AbstractValidator<DeleteProductImageVM>
    {
        public DeleteProductImageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("silinecek ürün resmine ait kimlik bilgisi olmalıdır.")
                .GreaterThan(0).WithMessage("0 dan büyük olmalıdır");
        }
    }
}
