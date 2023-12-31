﻿using Ahlatci.Shop.Application.Models.Dtos.Cities;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.Products;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ahlatci.Shop.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Route("product")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet("get")]
		public async Task<ActionResult<Result<List<ProductDto>>>> GetAllProduct()
		{
			var categories = await _productService.GetAllProducts();
			return Ok(categories);
		}

		//service içi doldurulacak
        [HttpGet("gett")]
        public async Task<ActionResult<Result<List<ProductWithCategoryDto>>>> GetAllProductWithDCategory()
        {
            var categories = await _productService.GetAllProductsWithCategory();
            return Ok(categories);
        }


        [HttpGet("get/{id:int}")]
		public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id)
		{
			var category = await _productService.GetProductById(id);
			return Ok(category);
		}

		[HttpPost("create")]
		public async Task<ActionResult<Result<int>>> CreateProduct(CreateProductVM createProductVM)
		{
			
			var categoryId = await _productService.CreateProduct(createProductVM);
			return Ok(categoryId);
		}

		[HttpPut("update/{id:int}")]
		public async Task<ActionResult<Result<int>>> UpdateProduct(int id, UpdateProductVM updateProductVM)
		{
			if (id != updateProductVM.Id)
			{
				return BadRequest();
			}
			
			var productId = await _productService.UpdateProduct(updateProductVM);
			return Ok(productId);
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<ActionResult<Result<int>>> DeleteProduct(int id)
		{
			var productId = await _productService.DeleteProduct(id);
			return Ok(productId);
		}
	}
}
