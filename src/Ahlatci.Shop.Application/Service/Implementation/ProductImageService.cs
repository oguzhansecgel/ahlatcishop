using Ahlatci.Shop.Application.Models.Dtos.ProductImages;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using Ahlatci.Shop.Application.Service.Abstract;
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
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;
        public ProductImageService( IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<ProductImagesDto>>> GetAllImagesByProduct(GetAllProductImageByProductVM getByProductVM)
        {
            var result = new Result<List<ProductImagesDto>>();

            var productImages = await _unitWork.GetRepository<Product>().GetByFilterAsync(x=>x.Id == getByProductVM.ProductId); 
            var productImageDtos = _mapper.Map<List<Product>, List<ProductImagesDto>>(productImages);
            result.Data = productImageDtos;
            return result;
        }

        public async Task<Result<List<ProductImageWithProductDto>>> GetAllProductImagesWithProduct(GetAllProductImageByProductVM getByProductVM)
        {
            var result = new Result<List<ProductImageWithProductDto>>();

            var productImages = await _unitWork.GetRepository<ProductImage>().GetByFilterAsync(x => x.Id == getByProductVM.ProductId);
            var productImageDtos = _mapper.Map<List<ProductImage>, List<ProductImageWithProductDto>>(productImages);

            result.Data = productImageDtos;
            return result;
        }

        public Task<Result<int>> CreateProduct(CreateProductImageVM createProductImageVM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteProduct(DeleteProductImageVM deleteProductImageVM)
        {
            throw new NotImplementedException();
        }

    }
}
