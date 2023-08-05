using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Validators.Accounts
{
	public class LoginValidator : AbstractValidator<LoginViewModel>
	{
        public LoginValidator()
        {
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Kullanıcı adı bilgisi boş geçilemez")
				.MaximumLength(10).WithMessage("Kullanıcı adı 10 karakterden fazla veri girişi yapılamaz.");


			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Parola bilgisi boş geçilemez")
				.MaximumLength(10).WithMessage("Parola 10 karakterden fazla veri girişi yapılamaz.");
		}
    }
}
