using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Domain.Entites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.AutoMappings
{
	public class DomainToDto : Profile
	{
		public DomainToDto()
		{
			CreateMap<Catergory, CategoryDto>();
		}
	}
}
