using Ahlatci.Shop.Application.Models.Dtos.Cities;
using Ahlatci.Shop.Application.Models.RequestModels.Cities;
using Ahlatci.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Abstract
{
	public interface ICityService
	{
		Task<Result<List<CityDto>>> GetAllCities();
		Task<Result<CityDto>> GetCityById(int id);

		Task<Result<int>> CreateCity(CreateCityVM createCityVM);
		Task<Result<bool>> UpdateCity(UpdateCityVM updateCityVM);
		Task<Result<bool>> DeleteCity(int? id);
	}
}
