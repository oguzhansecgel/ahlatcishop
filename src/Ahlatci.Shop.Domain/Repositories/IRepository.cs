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
		Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
		Task<T> GetById(object id);
		Task Add(T entity);
		Task Delete(T entity);
		Task Delete(object id);
		Task Update(T entity);

	}
}
