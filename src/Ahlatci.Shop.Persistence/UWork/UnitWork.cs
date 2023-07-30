using Ahlatci.Shop.Domain.Common;
using Ahlatci.Shop.Domain.Repositories;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Persistence.Context;
using Ahlatci.Shop.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ahlatci.Shop.Persistence.UWork
{
	public class UnitWork : IUnitWork
	{
		private Dictionary<Type, object> _repositories;
		private readonly AhlatciContext _context;

		public UnitWork(AhlatciContext context)
		{
			_repositories = new Dictionary<Type, object>();
			_context = context;
		}


		public async Task<bool> CommitAsync()
		{
			var result = false;

			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{

					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
					result = true;
				}
				catch
				{

					await transaction.RollbackAsync();
					throw;

				}
			}

			return result;
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			if (_repositories.ContainsKey(typeof(IRepository<T>)))
			{
				return (IRepository<T>)_repositories[typeof(IRepository<T>)];
			}
			var repository = new Repository<T>(_context);
			_repositories.Add(typeof(IRepository<T>), repository);
			return repository;


		}



		#region Dispose

		bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				//.Net objelerini kaldır.
				_context.Dispose();
			}

			//Kullanılan harici dil kütüphaneleri (.Net ile yazılmamış external kütüphaneler)
			//Örneğin görüntü işlemi için kullanılacak bir C++ kütüphanesini bellekten at

			_disposed = true;
		}

		#endregion


	}
}
