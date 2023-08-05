using Ahlatci.Shop.Application.Behaviors;
using Ahlatci.Shop.Application.Exceptions;
using Ahlatci.Shop.Application.Models.Dtos.Accounts;
using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Validators.Accounts;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

		[ValidationBehavior(typeof(RegisterValidator))]
		public async Task<bool> Register(RegisterVM createUserVM)
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


		public async Task<Result<TokenDto>> Login(LoginViewModel loginViewModel)
		{
			var result = new Result<TokenDto>();
			var hashedPassword = CipherUtil
			   .EncryptString(_configuration["AppSettings:SecretKey"],loginViewModel.Password);
			var existsAccount = await _uWork.GetRepository<Account>().
				GetSingleByFilterAsync(x => x.Username == loginViewModel.Username && x.Password==hashedPassword);
		
			if(existsAccount is null)
			{
				throw new NotFoundException($"Kullanıcı adı veya şifre hatalı");
			}
			//account ile eşleşen kullanıyı bulalım.
			var existsCustomer = await _uWork.GetRepository<Customer>().GetById(existsAccount.CustomerId);

			if(existsCustomer is null ) 
			{ 
				throw new NotFoundException($"Kullanıcı adı veya şifre hatalı");

			}

			var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
			var expireDate = DateTime.Now.AddMinutes(expireMinute);

			//Token'i üret ve return et.
			var tokenString = GenerateJwtToken(existsAccount, existsCustomer,expireDate);

			result.Data = new TokenDto
			{
				Token = tokenString,
				ExpireDate = expireDate
			};

			return result;
		}
		//githubdan çekilecek
		private string GenerateJwtToken(Account account,Customer customer ,DateTime expireDate)
		{
			var secretKey = _configuration["Jwt:SigninKey"];
			var issuer = _configuration["Jwt:Issuer"];
			var audiance = _configuration["Jwt:Audiance"];

			var claims = new Claim[]
			{
				new Claim(ClaimTypes.Role,((int)account.Role).ToString()),
				new Claim("Username",account.Username),
				new Claim("Email",customer.Email)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = audiance,
				Issuer = issuer,
				Subject = new ClaimsIdentity(claims),
				Expires = expireDate, // Token süresi (örn: 20 dakika)
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
	
}
