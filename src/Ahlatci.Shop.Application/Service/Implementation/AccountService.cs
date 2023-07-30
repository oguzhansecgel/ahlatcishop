using Ahlatci.Shop.Application.Behaviors;
using Ahlatci.Shop.Application.Exceptions;
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
			//aynı kullanıcı adı daha önce girilmiş mi _ 
			var usernameExists = await _uWork.GetRepository<Account>().AnyAsync(x => x.Username.Trim().ToUpper() == createUserVM.Username.Trim().ToUpper());
			if (usernameExists) 
			{
				throw new AllReadyExistException($"{createUserVM.Username} daha önce seçilmiştir. Farklı bir kullanıcı adı seçiniz.");
			}

			//aynı eposta adresi daha önce girilmiş mi _ 
			var mailExist = await _uWork.GetRepository<Customer>().AnyAsync(x => x.Email.Trim().ToUpper() == createUserVM.Email.Trim().ToUpper());
			if (mailExist)
			{
				throw new AllReadyExistException($"{createUserVM.Email} eposta adresi kullanımdadır.");
			}

			//gelen model customer türüne maplandi
			var customerEntity = _mapper.Map<Customer>(createUserVM);
			//gelen model account türüne maplandi
			var accountEntity = _mapper.Map<Account>(createUserVM);

			accountEntity.Password = CipherUtil
			   .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);


			_uWork.GetRepository<Customer>().Add(customerEntity);
			_uWork.GetRepository<Account>().Add(accountEntity);
			accountEntity.Customer = customerEntity;


			var customerAccountCreateResult = await _uWork.CommitAsync();

			if(customerAccountCreateResult)
			{
				accountEntity.CustomerId = customerEntity.Id;
				var accountCustomerIdUdateResult =await _uWork.CommitAsync();
				return customerAccountCreateResult;
			}

			return false;
		}
	}
}
