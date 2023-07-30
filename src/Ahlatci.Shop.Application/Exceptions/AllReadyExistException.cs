using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Exceptions
{
	public class AllReadyExistException : Exception
	{
		public AllReadyExistException(string message) : base(message)
		{

		}

		public AllReadyExistException() : base()
		{

		}
	}
}
