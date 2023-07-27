using ArxOne.MrAdvice.Advice;
using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Behaviors
{
	public class ValidationAspect :Attribute , IMethodAdvice
	{
		public void Advise(MethodAdviceContext context)
		{
			// metot çalışmadan önce devreye girecek kodlar 

			context.Proceed();

			// metod çalıştıktan sonra devreye girecek kodlar

		}

	 
	}
}
