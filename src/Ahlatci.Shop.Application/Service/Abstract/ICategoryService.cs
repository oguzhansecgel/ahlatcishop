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

        #region Insert,update,delete
        Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        Task<Result<int>> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel);
        #endregion

    }
}
