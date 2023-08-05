﻿using Ahlatci.Shop.Application.Models.Dtos.Category;
using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Authorization;
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


		[HttpPost("register")]
		[Authorize]

		public async Task<ActionResult<Result<int>>> Register(RegisterVM createUserVM)
		{
			var result = await _accountService.Register(createUserVM);
			return Ok(result);
		}
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<ActionResult<Result<int>>> Login(LoginViewModel loginViewModel)
		{
			var result = await _accountService.Login(loginViewModel);
			return Ok(result);
		}

	}
}
