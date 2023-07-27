using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Ahlatci.Shop.Application.Wrapper;

namespace Ahlatci.Shop.Api.Filters
{
	public class ExceptionHandleFilters
	{
		public class ExceptionHandlerFilter : IExceptionFilter
		{
 
			public void OnException(ExceptionContext context)
			{
				var result = new Result<dynamic>()
				{
					Errors = new List<string>
					{
						context.Exception.Message
					},
					Success = false
				};
				context.Result = new JsonResult(result);
				context.HttpContext.Response.StatusCode = 400;
				context.ExceptionHandled = true;
			}
		}

 
	}
}
