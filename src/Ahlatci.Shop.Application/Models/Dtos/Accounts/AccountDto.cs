using Ahlatci.Shop.Application.Models.Dtos.Customers;
using Ahlatci.Shop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Models.Dtos.Accounts
{
	public class AccountDto
	{
		public int CustomerId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public string LastUserIp { get; set; }
		public Roles Role { get; set; }

		public CustomerDto Customer { get; set; }


	}
}
