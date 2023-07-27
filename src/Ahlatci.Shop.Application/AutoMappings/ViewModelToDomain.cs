using Ahlatci.Shop.Application.Models.RequestModels;
using Ahlatci.Shop.Domain.Entites;
using AutoMapper;
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

		}
	}
}
