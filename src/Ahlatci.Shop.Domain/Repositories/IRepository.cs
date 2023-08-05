using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAllAsync();
		Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
		Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter);
		Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
		Task<T> GetById(object id);
		 void Add(T entity);
		void Delete(T entity);
		void Delete(object id);
		void Update(T entity);

	}
}
