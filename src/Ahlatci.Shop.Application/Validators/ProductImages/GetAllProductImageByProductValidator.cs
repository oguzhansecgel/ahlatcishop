using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.ProductImages
{
    public class GetAllProductImageByProductValidator : AbstractValidator<GetAllProductImageByProductVM>
    {
        public GetAllProductImageByProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("silinecek ürün resmine ait kimlik bilgisi olmalıdır.")
                .GreaterThan(0).WithMessage("ürüne ait kimlik bilgisi 0 dan büyük olmalıdır");
        }
    }
}
