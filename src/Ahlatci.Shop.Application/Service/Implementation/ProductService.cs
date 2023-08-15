using Ahlatci.Shop.Application.Behaviors;
using Ahlatci.Shop.Application.Exceptions;
using Ahlatci.Shop.Application.Models.Dtos.Cities;
using Ahlatci.Shop.Application.Models.Dtos.ProductImages;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.Cities;
using Ahlatci.Shop.Application.Models.RequestModels.Products;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Validators.Categories;
using Ahlatci.Shop.Application.Validators.Products;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.UWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Implementation
{
	public class ProductService : IProductService
	{
		private readonly IMapper _mapper;
		private readonly IUnitWork _uwork;

		public ProductService(IMapper mapper, IUnitWork uwork)
		{
			_mapper = mapper;
			_uwork = uwork;
		}

		public async Task<Result<List<ProductDto>>> GetAllProducts()
		{
			var result = new Result<List<ProductDto>>();
			var productEntites = await _uwork.GetRepository<Product>().GetAllAsync();
			var productDtos = _mapper.Map<List<Product>, List<ProductDto>>(productEntites);
			result.Data = productDtos;
			return result;
		}


        public async Task<Result<List<ProductWithCategoryDto>>> GetAllProductsWithCategory()
        {

            var result = new Result<List<ProductWithCategoryDto>>();

            var products = await _uwork.GetRepository<Product>().GetAllAsync();
			var productDtos = _mapper.Map<List<Product>, List<ProductWithCategoryDto>>(products);
 

            result.Data = productDtos;
            return result;
        }
        public async Task<Result<ProductDto>> GetProductById(int id)
		{
			var result = new Result<ProductDto>();
			var productEntity = await _uwork.GetRepository<Product>().GetById(id);

			var productDto= _mapper.Map<ProductDto>(productEntity);

			result.Data = productDto;

			return result;
		}
        [ValidationBehavior(typeof(CreateProductValidator))]

        public async Task<Result<int>> CreateProduct(CreateProductVM createProductVM)
		{
			var result = new Result<int>();
			var productEntity = _mapper.Map<Product>(createProductVM);
			var categoryById = await _uwork.GetRepository<Catergory>().GetById(createProductVM.CategoryId);
			if(categoryById == null)
			{
				throw new NotFoundException($"{createProductVM.CategoryId} numaralı category bulunamadı.");

			}

			_uwork.GetRepository<Product>().Add(productEntity);
			await _uwork.CommitAsync();
			result.Data = productEntity.Id;
			return result;
 

		}

		public async Task<Result<bool>> DeleteProduct(int? id)
		{
			var result = new Result<bool>();

			var productById = await _uwork.GetRepository<Product>().GetById(id);
			if (productById is null)
			{
				throw new NotFoundException($"{id} numaralı ürün bulunamadı.");
			}

			_uwork.GetRepository<Product>().Delete(productById);
			result.Data = await _uwork.CommitAsync();
			return result;
		}

		public async Task<Result<bool>> UpdateProduct(UpdateProductVM updateProductVM)
		{
			var result = new Result<bool>();


			var existsProductEntity = await _uwork.GetRepository<Product>().GetById(updateProductVM.Id);

			_mapper.Map(updateProductVM, existsProductEntity);

			_uwork.GetRepository<Product>().Update(existsProductEntity);
			result.Data = await _uwork.CommitAsync();

			return result;
		}

    }
}
