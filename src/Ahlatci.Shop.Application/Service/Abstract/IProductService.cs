using Ahlatci.Shop.Application.Models.Dtos.Cities;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.Cities;
using Ahlatci.Shop.Application.Models.RequestModels.Products;
using Ahlatci.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Abstract
{
	public interface IProductService
	{
		Task<Result<List<ProductDto>>> GetAllProducts();
		Task<Result<List<ProductWithCategoryDto>>> GetAllProductsWithCategory();
        Task<Result<ProductDto>> GetProductById(int id);

		Task<Result<int>> CreateProduct(CreateProductVM createProductVM);
		Task<Result<bool>> UpdateProduct(UpdateProductVM updateProductVM);
		Task<Result<bool>> DeleteProduct(int? id);
	}
}
