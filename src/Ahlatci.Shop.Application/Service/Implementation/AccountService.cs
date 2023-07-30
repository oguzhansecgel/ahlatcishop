using Ahlatci.Shop.Application.Behaviors;
using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Validators.Accounts;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Implementation
{
	public class AccountService : IAccountService
	{
		private readonly IMapper _mapper;
		private readonly IUnitWork _uWork;
		private readonly IConfiguration _configuration;
		public AccountService(IMapper mapper, IUnitWork uWork, IConfiguration configuration)
		{
			_mapper = mapper;
			_uWork = uWork;
			_configuration = configuration;
		}
		[ValidationBehavior(typeof(CreateUserValidator))]
		public async Task<bool> CreateUser(CreateUserViewModel createUserVM)
		{
			//gelen model customer türüne maplandi
			var customerEntity = _mapper.Map<Customer>(createUserVM);
			//gelen model account türüne maplandi
			var accountEntity = _mapper.Map<Account>(createUserVM);

			accountEntity.Password = CipherUtil
			   .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);


			await _uWork.GetRepository<Customer>().Add(customerEntity);
			await _uWork.GetRepository<Account>().Add(accountEntity);

			var result = await _uWork.CommitAsync();
			return result;
		}
	}
}
