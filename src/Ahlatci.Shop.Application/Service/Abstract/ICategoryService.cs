using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Models.RequestModels;

namespace Ahlatci.Shop.Application.Service.Abstract
{
    public interface ICategoryService
    {
        //Dto => servisin dışarıya gönderdiği türler
        //Viewmodel => servisin dışarıdan aldığı parametreler
        #region select
        Task<List<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(int id);
        #endregion

        #region Insert,update,delete
        Task<int> CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        Task<int> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        Task<int> DeleteCategory(int id);
        #endregion

    }
}
