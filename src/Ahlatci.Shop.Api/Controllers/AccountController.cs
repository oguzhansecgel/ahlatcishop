using Ahlatci.Shop.Application.Models.Dtos.Category;
using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahlatci.Shop.Api.Controllers
{
	[ApiController]
	[Route("account")]

	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}


		[HttpPost("create")]
		public async Task<ActionResult<Result<int>>> CreateUser(CreateUserViewModel createUserVM)
		{
			var categoryId = await _accountService.CreateUser(createUserVM);
			return Ok(categoryId);
		}

	}
}
