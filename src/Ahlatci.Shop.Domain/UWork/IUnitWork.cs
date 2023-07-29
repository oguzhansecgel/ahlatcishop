using Ahlatci.Shop.Domain.Common;
using Ahlatci.Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.UWork
{
	public interface IUnitWork
	{
		public IRepository<T> GetRepository<T>() where T : BaseEntity;
		public Task<bool> CommitAsync();
	}
}
