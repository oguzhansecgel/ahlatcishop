using Ahlatci.Shop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Models.RequestModels.Accounts
{
	public class CreateUserViewModel
	{

		public int CityId { get; set; }
		public string IdentityNumber { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime Birtdate { get; set; }
		public Gender Gender { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string PasswordAgain { get; set; }
		public Roles Role { get; set; }
	}
}
