using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Domain.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Accounts
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserVM>
	{
		public UpdateUserValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Güncellenecek kullanıcı kimlik numarası gönderilmelidir");

			RuleFor(x => x.CityId)
				.NotEmpty().WithMessage("Geçerli bir il bilgisi gönderilmelidir.")
				.LessThan(82).WithMessage("Geçersiz bir il numarası gönderildi.");
			RuleFor(x => x.IdentityNumber)
				.NotEmpty().WithMessage("Tc kimlik boş olamaz")
				.MaximumLength(11).WithMessage("Geçerli bir tc kimlik numarası giriniz.")
				.MinimumLength(11).WithMessage("Geçerli bir tc kimlik numarası giriniz.");

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Ad bilgisi boş geçilemez")
				.MaximumLength(30).WithMessage("Ad 30 karakterden fazla veri girişi yapılamaz")
				.MinimumLength(2).WithMessage("Ad 2 karakterden az veri girişi yapılamaz");

			RuleFor(x => x.Surname)
				.NotEmpty().WithMessage("Soyad bilgisi boş geçilemez")
				.MaximumLength(30).WithMessage("Soyad 30 karakterden fazla veri girişi yapılamaz")
				.MinimumLength(2).WithMessage("Soyad 2 karakterden az veri girişi yapılamaz");


			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Telefon numarası bilgisi boş geçilemez")
				.MaximumLength(13).WithMessage("Telefon numarası 13 karakterden fazla veri girişi yapılamaz");

			RuleFor(x => x.Birtdate)
				.NotEmpty().WithMessage("Doğum Tarihi bilgisi boş geçilemez");

			RuleFor(x => x.Gender)
				.NotEmpty().WithMessage("Cinsiyet bilgisi boş geçilemez")
				.IsInEnum().WithMessage("Cinsiyet bilgisi geçerli değil.(1 veya 2 olabilir)");


		}
	}
}

