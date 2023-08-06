using Ahlatci.Shop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Service.Abstract
{
	public interface ILoggedUserService
	{
		int? UserId { get; }
		Roles? Role { get; }
		string UserName { get; }
		string Email { get; }

	}
}
