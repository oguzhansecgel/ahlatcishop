using Ahlatci.Shop.Domain.Common;
using Ahlatci.Shop.Domain.Repositories;
using Ahlatci.Shop.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Persistence.Repositories
{
	public class Repository<T> : IRepository<T>
		where T : BaseEntity
	{
		private readonly DbSet<T> _dbSet;

		public Repository(AhlatciContext dbContext)
		{
			_dbSet = dbContext.Set<T>();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
		{
			return await _dbSet.Where(filter).ToListAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
		{
			return await _dbSet.AnyAsync(filter);
		}

		public async Task<T> GetById(object id)
		{
			var entity = await _dbSet.FindAsync(id);
			return entity;
		}

		public void Add(T entity)
		{
			_dbSet.AddAsync(entity);

		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);

		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);

		}

		public void Delete(object id)
		{
			var item = _dbSet.Find(id);
			_dbSet.Remove(item);
		}
	}
}
