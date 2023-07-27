using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Models.RequestModels;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
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
        public async Task<ActionResult<Result<List<CategoryDto>>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

		[HttpGet("get/{id:int}")]
		public async Task<ActionResult<Result<CategoryDto>>> GetCategoryById(int id)
		{
			var category = await _categoryService.GetCategoryById(new GetCategoryByIdVM { Id = id });
			return Ok(category);
		}

		[HttpPost("create")]
		public async Task<ActionResult<Result<int>>> CreateCategory(CreateCategoryViewModel createCategoryVM)
		{
			var categoryId = await _categoryService.CreateCategory(createCategoryVM);
			return Ok(categoryId);
		}

		[HttpPut("update/{id:int}")]
		public async Task<ActionResult<Result<int>>> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryVM)
		{
			if (id != updateCategoryVM.Id)
			{
				return BadRequest();
			}
			var categoryId = await _categoryService.UpdateCategory(updateCategoryVM);
			return Ok(categoryId);
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<ActionResult<Result<int>>> DeleteCategory(int id)
		{
			var categoryId = await _categoryService.DeleteCategory(new DeleteCategoryViewModel { Id = id });
			return Ok(categoryId);
		}

	}
}