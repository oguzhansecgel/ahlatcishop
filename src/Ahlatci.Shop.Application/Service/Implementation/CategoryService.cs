using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Models.RequestModels;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Ahlatci.Shop.Application.Service.Implementation
{
	public class CategoryService : ICategoryService
    {
        private readonly AhlatciContext _context;
        private readonly IMapper _mapper;
		public CategoryService(AhlatciContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Result<List<CategoryDto>>> GetAllCategories()
		{
			var result = new Result<List<CategoryDto>>();

            var categoryDtos = await _context.Catergories
				.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
            result.Data=categoryDtos;

			return result;
		}

		public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
		{
            var categoryExist = await _context.Catergories.AnyAsync(x=>x.Id == getCategoryByIdVM.Id);
            if(!categoryExist)
            {
                throw new Exception($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı");
            }

            var categoryDto = await _context.Catergories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == getCategoryByIdVM.Id);
			var result = new Result<CategoryDto>();
            result.Data = categoryDto;
            return result;
		}
		public async Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            //// entity üretildi
            //var categoryEntity = new Catergory
            //{
            //    Name = createCategoryViewModel.CategoryName
            //};
            //// üretilen entity kategori koleksiyonuna ekleniyor

            var categoryEntity = _mapper.Map<CreateCategoryViewModel, Catergory>(createCategoryViewModel);
            var result = new Result<int>();
            await _context.Catergories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            result.Data = categoryEntity.Id;
            return result;

        }
        public async Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == deleteCategoryViewModel.Id);
            var result = new Result<int>();
            if (!categoryExists)
            {
                throw new Exception($"{deleteCategoryViewModel.Id} numaralı kategori bulunamadı.");
            }
            var existsCategory = await _context.Catergories.FindAsync(deleteCategoryViewModel.Id);
            // liste kolununda silindi olarak işaretlenecek ve listelemede getirilmeyecek o amaçla update yazdık
            existsCategory.IsDeleted = true;
            _context.Catergories.Update(existsCategory);
            await _context.SaveChangesAsync();
            result.Data = existsCategory.Id;
            return result;

        }

        public async Task<Result<int>> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var result = new Result<int>();
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == updateCategoryViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{updateCategoryViewModel.Id} numaralı kategori bulunamadı.");
            }

            var updatedCategory = _mapper.Map<UpdateCategoryViewModel, Catergory>(updateCategoryViewModel);

 
            _context.Catergories.Update(updatedCategory);
            await _context.SaveChangesAsync();
            result.Data = updatedCategory.Id;
            return result;
        }

	 







		//
	}
}
