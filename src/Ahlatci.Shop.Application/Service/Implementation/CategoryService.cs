﻿using Ahlatci.Shop.Application.Behaviors;
using Ahlatci.Shop.Application.Exceptions;
using Ahlatci.Shop.Application.Models.Dtos.Category;
using Ahlatci.Shop.Application.Models.RequestModels.Categories;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Validators.Categories;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.Repositories;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Persistence.Context;
using AutoMapper;

namespace Ahlatci.Shop.Application.Service.Implementation
{
    public class CategoryService : ICategoryService
	{
		private readonly IMapper _mapper;
		private readonly IUnitWork _db;

		public CategoryService(IMapper mapper, IUnitWork db)
		{
			_mapper = mapper;
			_db = db;
		}

		[PerformanceBehavior]
		public async Task<Result<List<CategoryDto>>> GetAllCategories()
		{
			var result = new Result<List<CategoryDto>>();

			var categoryEntites = await _db.GetRepository<Catergory>().GetAllAsync();
			var categoryDtos = _mapper.Map<List<Catergory>, List<CategoryDto>>(categoryEntites);
			result.Data = categoryDtos;

			return result;
		}


		[ValidationBehavior(typeof(GetCategoryByIdValidator))]
		public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
		{
			var result = new Result<CategoryDto>();

			//var categoryExists = await _context.Categories.AnyAsync(x=>x.Id == getCategoryByIdVM.Id);
			var categoryExists = await _db.GetRepository<Catergory>().AnyAsync(x => x.Id == getCategoryByIdVM.Id);
			if (!categoryExists)
			{
				throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
			}

			var categoryEntity = await _db.GetRepository<Catergory>().GetById(getCategoryByIdVM.Id);

			var categoryDto = _mapper.Map<Catergory, CategoryDto>(categoryEntity);

			result.Data = categoryDto;

			return result;
		}


		[ValidationBehavior(typeof(CreateCategoryValidator))]
		public async Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryVM)
		{
			var result = new Result<int>();

			var categoryEntity = _mapper.Map<CreateCategoryViewModel, Catergory>(createCategoryVM);

			_db.GetRepository<Catergory>().Add(categoryEntity);
			await _db.CommitAsync();

			result.Data = categoryEntity.Id;

			return result;
		}


		[ValidationBehavior(typeof(DeleteCategoryValidator))]
		public async Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryVM)
		{
			var result = new Result<int>();

			var categoryExists = await _db.GetRepository<Catergory>().AnyAsync(x => x.Id == deleteCategoryVM.Id);
			if (!categoryExists)
			{
				throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
			}

			_db.GetRepository<Catergory>().Delete(deleteCategoryVM.Id);
			await _db.CommitAsync();

			result.Data = deleteCategoryVM.Id;

			return result;
		}


		[ValidationBehavior(typeof(UpdateCategoryValidator))]
		public async Task<Result<int>> UpdateCategory(UpdateCategoryViewModel updateCategoryVM)
		{
			var result = new Result<int>();

			var existsCategory = await _db.GetRepository<Catergory>().GetById(updateCategoryVM.Id);
			if (existsCategory is null)
			{
				throw new Exception($"{updateCategoryVM} numaralı kategori bulunamadı.");
			}

			//var updateCategory = _mapper.Map<UpdateCategoryVM,Category>(updateCategoryVM);

			var updatedCategory = _mapper.Map(updateCategoryVM, existsCategory);

			_db.GetRepository<Catergory>().Update(updatedCategory);
			await _db.CommitAsync();

			result.Data = updatedCategory.Id;

			return result;
		}
		//
	}
}
