using Ahlatci.Shop.Application.Models.Dtos;
using Ahlatci.Shop.Application.Models.RequestModels;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly AhlatciContext _context;

        public CategoryService(AhlatciContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            // entity üretildi
            var categoryEntity = new Catergory
            {
                Name = createCategoryViewModel.CategoryName
            };
            // üretilen entity kategori koleksiyonuna ekleniyor
            await _context.Catergories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            return categoryEntity.Id;

        }

        public async Task<int> DeleteCategory(int id)
        {
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == id);
            if (!categoryExists)
            {
                throw new Exception($"{id} numaralı kategori bulunamadı.");
            }
            var existsCategory = await _context.Catergories.FindAsync(id);
            // liste kolununda silindi olarak işaretlenecek ve listelemede getirilmeyecek o amaçla update yazdık
            existsCategory.IsDeleted = true;
            _context.Catergories.Update(existsCategory);
            await _context.SaveChangesAsync();
            return existsCategory.Id;

        }

        public async Task<int> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var categoryExists = await _context.Catergories.AnyAsync(x => x.Id == updateCategoryViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{updateCategoryViewModel.Id} numaralı kategori bulunamadı.");
            }

            var existsCategory = await _context.Catergories.FindAsync(updateCategoryViewModel.Id);
            // liste kolununda silindi olarak işaretlenecek ve listelemede getirilmeyecek o amaçla update yazdık
            existsCategory.Name = updateCategoryViewModel.CatergoryName;
            _context.Catergories.Update(existsCategory);
            await _context.SaveChangesAsync();

            return existsCategory.Id;
        }


        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Catergories.Select(x =>
            new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var categoryEntity = await _context.Catergories.FindAsync(id);
            var categoryDto = new CategoryDto
            {
                Id = id,
                Name = categoryEntity.Name,

            };
            return categoryDto;
        }




        



        //
    }
}
