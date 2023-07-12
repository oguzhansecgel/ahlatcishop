using System.Linq.Expressions;

namespace Ahlatci.Shop.Persistence.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		//CRUD İşlemler. 
		#region Read

		Task<List<T>> GettAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T
			object>>[] includes);

		#endregion

		#region Inser, Update, Delete



		#endregion
	}
}
