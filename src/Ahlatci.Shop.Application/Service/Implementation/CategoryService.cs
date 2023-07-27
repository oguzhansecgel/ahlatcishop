using Ahlatci.Shop.Application.Exceptions;
using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Models.RequestModels;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Validators;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ahlatci.Shop.Application.Behaviors;
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

        //Automapper : Bir modeli başka bir modele çevirmek için kullanılıyor.

        [PerformanceBehavior]
        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var result = new Result<List<CategoryDto>>();

            //var categories = await _context.Categories.ToListAsync();
            ////_mapper.Map<T1,T2>  T1 tipindeki kaynak objeyi T2 tipindeki hedef objeye çevirir.
            //var categoryDtos = _mapper.Map<List<Category> ,List<CategoryDto>>(categories);

            var categoryDtos = await _context.Catergories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = categoryDtos;

            return result;
        }


        [ValidationBehavior(typeof(GetCategoryByIdValidator))]
        public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
        {
            var result = new Result<CategoryDto>();

            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == getCategoryByIdVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
            }

            var categoryDto = await _context.Catergories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == getCategoryByIdVM.Id);

            result.Data = categoryDto;
            return result;
        }


        [ValidationBehavior(typeof(CreateCategoryValidator))]
        public async Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryVM)
        {
            var result = new Result<int>();

            var categoryEntity = _mapper.Map<CreateCategoryViewModel, Catergory>(createCategoryVM);

            //Üretilen entity kategori koleksiyonuna ekleniyor
            await _context.Catergories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            //Db kayıt işleminden sonra herhangi bir sıkıntı yoksa bu kategori için atanan entity geri döner.
            result.Data = categoryEntity.Id;
            return result;
        }


        [ValidationBehavior(typeof(DeleteCategoryValidator))]
        public async Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryVM)
        {
            var result = new Result<int>();

            //Gönderilen id bilgisine karşılık gelen bir kategori var mı?
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == deleteCategoryVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
            }

            //Veritabanında kayıtlı kategoriyi getirelim.
            var existsCategory = await _context.Catergories.FindAsync(deleteCategoryVM.Id);
            //Silindi olarak işaretleyelim.
            existsCategory.IsDeleted = true;
            //Güncellemeyi veritabanına yansıtalım.
            _context.Catergories.Update(existsCategory);
            await _context.SaveChangesAsync();

            result.Data = existsCategory.Id;
            return result;
        }

        [ValidationBehavior(typeof(UpdateCategoryValidator))]
        public async Task<Result<int>> UpdateCategory(UpdateCategoryViewModel updateCategoryVM)
        {
            var result = new Result<int>();

            //Gönderilen id bilgisine karşılık gelen bir kategori var mı?
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == updateCategoryVM.Id);
            if (!categoryExists)
            {
                throw new Exception($"{updateCategoryVM} numaralı kategori bulunamadı.");
            }

            var updatedCategory = _mapper.Map<UpdateCategoryViewModel, Catergory>(updateCategoryVM);

            ////Veritabanında kayıtlı kategoriyi getirelim.
            //var existsCategory = await _context.Categories.FindAsync(updateCategoryVM.Id);
            ////Silindi olarak işaretleyelim.
            //existsCategory.Name = updateCategoryVM.CategoryName;

            //Güncellemeyi veritabanına yansıtalım.
            _context.Catergories.Update(updatedCategory);
            await _context.SaveChangesAsync();

            result.Data = updatedCategory.Id;
            return result;
        }

        //
    }
}
