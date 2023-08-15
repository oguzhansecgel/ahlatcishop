using Ahlatci.Shop.Application.Models.Dtos.ProductImages;
using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Ahlatci.Shop.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[Route("productImage")]
	public class ProductImageController : ControllerBase
	{
		private readonly IProductImageService _productImageService;

		public ProductImageController(IProductImageService productImageService)
		{
            _productImageService = productImageService;
		}
        [HttpGet("getAllByProduct/{id:int?}")]
        public async Task<ActionResult<Result<List<ProductImagesDto>>>> GetAllImagesByProduct(int? id)
        {
            var result = await _productImageService.GetAllImagesByProduct(new GetAllProductImageByProductVM { ProductId = id });
            return Ok(result);
        }

        [HttpGet("getAllDetailByProduct/{id:int?}")]
        public async Task<ActionResult<Result<List<ProductImageWithProductDto>>>> GetAllImagesWithProductByProduct(int? id)
        {
            var result = await _productImageService.GetAllProductImagesWithProduct(new GetAllProductImageByProductVM { ProductId = id });
            return Ok(result);
        }


        [HttpPost]
		public async Task<ActionResult<Result<int>>> CreateProductImage([FromForm]CreateProductImageVM createProductImageVM)
		{
			
			var imageId = await _productImageService.CreateProductImage(createProductImageVM);
			return Ok(imageId);
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<ActionResult<Result<int>>> DeleteProductImage(int id)
		{

			var result = await _productImageService.DeleteProductImage(new DeleteProductImageVM{ Id = id });
            return Ok(result);
        }
    }
}
