using Ahlatci.Shop.Application.Models.RequestModels.Accounts;
using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.AutoMappings
{
	public class ViewModelToDomain : Profile
	{
		public ViewModelToDomain()
		{
			CreateMap<CreateCategoryViewModel, Catergory>()
				.ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));

			CreateMap<UpdateCategoryViewModel, Catergory>()
				.ForMember(x => x.Name, y => y.MapFrom(e => e.CatergoryName));

			//Kullanıcı oluşturma isteği
			CreateMap<CreateUserViewModel, Customer>();
			CreateMap<CreateUserViewModel, Account>();
				

		}
	}
}
