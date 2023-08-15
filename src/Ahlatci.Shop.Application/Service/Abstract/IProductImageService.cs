using Ahlatci.Shop.Application.Models.Dtos.ProductImages;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using Ahlatci.Shop.Application.Models.RequestModels.Products;
using Ahlatci.Shop.Application.Validators.ProductImages;
using Ahlatci.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Abstract
{
    public interface IProductImageService
    {
        Task<Result<List<ProductImagesDto>>> GetAllImagesByProduct(GetAllProductImageByProductVM getByProductVM);
        Task<Result<List<ProductImageWithProductDto>>> GetAllProductImagesWithProduct(GetAllProductImageByProductVM getByProductVM);

        Task<Result<int>> CreateProductImage(CreateProductImageVM createProductImageVM);
        Task<Result<int>> DeleteProductImage(DeleteProductImageVM deleteProductImageVM);
    }
}
