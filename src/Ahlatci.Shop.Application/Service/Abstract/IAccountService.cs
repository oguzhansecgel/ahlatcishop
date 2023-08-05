using Ahlatci.Shop.Application.Models.Dtos.Accounts;
using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Abstract
{
    public interface IAccountService
    {
		Task<bool> Register(RegisterVM createUserVM);
		Task<Result<TokenDto>> Login(LoginViewModel loginViewModel);
	}
}
