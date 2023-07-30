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
		private readonly IServiceProvider _serviceProvider;
		private readonly AhlatciContext _context;

		public UnitWork(IServiceProvider serviceProvider, AhlatciContext context)
		{
			_repositories = new Dictionary<Type, object>();
			_serviceProvider = serviceProvider;
			_context = context;
		}


		public async Task<bool> CommitAsync()
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					await _context.SaveChangesAsync();
					transaction.Commit();

				}
				catch
				{
					await transaction.RollbackAsync();
					throw;

				}
				return true;
			}

		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			if (_repositories.ContainsKey(typeof(IRepository<T>)))
			{
				return (IRepository<T>)_repositories[typeof(IRepository<T>)];
			}
			var scope = _serviceProvider.CreateScope();

			var repository = scope.ServiceProvider.GetRequiredService<IRepository<T>>();
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
