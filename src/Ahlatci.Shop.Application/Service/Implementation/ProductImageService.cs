using Ahlatci.Shop.Application.Exceptions;
using Ahlatci.Shop.Application.Models.Dtos.ProductImages;
using Ahlatci.Shop.Application.Models.Dtos.Products;
using Ahlatci.Shop.Application.Models.RequestModels.ProductImages;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public ProductImageService(IMapper mapper, IUnitWork unitWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
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

        public async Task<Result<int>> CreateProductImage(CreateProductImageVM createProductImageVM)
        {
            var result = new Result<int>();

            var productExists = await _unitWork.GetRepository<Product>().AnyAsync(x => x.Id == createProductImageVM.ProductId);
            if(!productExists)
            {
                throw new NotFoundException($"{createProductImageVM.ProductId} numaralı ürün bulunamadı");
            }
            var fileName = PathUtil.GenerateFileName(createProductImageVM.UploadedImage);
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, _configuration["Paths:ProductImages"],fileName); 
            //dosya fiziksel olarak keydediliyor.
            using(FileStream fs = new FileStream(filePath,FileMode.Create))
            {
                createProductImageVM.UploadedImage.CopyTo(fs);
                fs.Close();
            }
            var productImageEntity = _mapper.Map<ProductImage>(createProductImageVM);
            productImageEntity.Path = Path.Combine(_configuration["Paths:ProductImages"],fileName);
            //Dosyaya ait bilgileri dbye yaz
            _unitWork.GetRepository<ProductImage>().Add(productImageEntity);
            await _unitWork.CommitAsync();

            result.Data = productImageEntity.Id;
            return result;
        }

        public async Task<Result<int>> DeleteProductImage(DeleteProductImageVM deleteProductImageVM)
        {
            var result = new Result<int>();

            var existsProductImage = await _unitWork.GetRepository<ProductImage>().GetById(deleteProductImageVM.Id);
            if(existsProductImage is null)
            {
                throw new NotFoundException($"{deleteProductImageVM.Id} numaralı ürün resmi bulunamadı");
            }

            _unitWork.GetRepository<ProductImage>().Delete(existsProductImage);
            await _unitWork.CommitAsync();

            var filePath =  Path.Combine(_hostingEnvironment.ContentRootPath,existsProductImage.Path);
            if(File.Exists(filePath)) 
            {

                File.Delete(filePath);

            }

            result.Data = existsProductImage.Id;
            return result;
        }

 
    }
}
