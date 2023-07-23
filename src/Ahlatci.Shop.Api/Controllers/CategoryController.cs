using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Ahlatci.Shop.Api.Controllers
{

    //buna eriþmek isteyen kiþi endpoint url : [ControllerRoute]/[ActionRoute]
    //category/getAll
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
   
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetALL")]
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return categories;
        }
    }
}