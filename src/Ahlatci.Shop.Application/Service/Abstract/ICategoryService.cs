using Ahlatci.Shop.Application.Models.Dtos.Category;
using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using Ahlatci.Shop.Application.Wrapper;

namespace Ahlatci.Shop.Application.Service.Abstract
{
	public interface ICategoryService
	{
		//Dto => servisin dışarıya gönderdiği türler
		//Viewmodel => servisin dışarıdan aldığı parametreler
		#region select
		Task<Result<List<CategoryDto>>> GetAllCategories();
		Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM);

		#endregion

		#region Insert, Update, Delete
		Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryVM);
		Task<Result<int>> UpdateCategory(UpdateCategoryViewModel updateCategoryVM);
		Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryVM);
		#endregion

	}
}
