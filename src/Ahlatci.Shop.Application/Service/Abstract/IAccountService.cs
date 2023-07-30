using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Abstract
{
    public interface IAccountService
    {
		Task<bool> CreateUser(CreateUserViewModel createUserVM);

	}
}
