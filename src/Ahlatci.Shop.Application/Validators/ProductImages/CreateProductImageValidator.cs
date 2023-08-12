using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.ProductImages
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageVM>
    {
        public CreateProductImageValidator()
        {
            var allowedContentTypes = new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif", "image/tiff" };

            RuleFor(x=>x.ProductId)
                .NotEmpty().WithMessage("Ürün kimlik bilgisi boş olamaz");


            RuleFor(x => x.UploadedImage)
                .NotNull().WithMessage("Resim dosyası seçilmelidir.")
                .Must(x=>x.Length>2*1024*1024).WithMessage("Resim dosya boyutu 2 MB'dan büyük olamaz.")
                .Must(x=>allowedContentTypes.Contains(x.ContentType)).WithMessage("Sadece resim dosyası seçilebilir");
        }
    }
}
