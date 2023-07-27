using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Ahlatci.Shop.Application.Wrapper;
using Ahlatci.Shop.Application.Exceptions;

namespace Ahlatci.Shop.Api.Filters
{
	public class ExceptionHandleFilters
	{
		public class ExceptionHandlerFilter : IExceptionFilter
		{
 
			public void OnException(ExceptionContext context)
			{
                var result = new Result<dynamic>() { Success = false };

                if (context.Exception is NotFoundException notFoundException)
                {
                    //var notFoundException = context.Exception as NotFoundException;
                    result.Errors = new List<string> { notFoundException.Message };
                }
                else if (context.Exception is ValidateException validationException)
                {
                    result.Errors.AddRange(validationException.ErrorMessages);
                }
                else
                {
                    result.Errors = new List<string> { context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message };
                }

 

                context.Result = new JsonResult(result);
                context.HttpContext.Response.StatusCode = 400;

                context.ExceptionHandled = true;
            }
		}

 
	}
}
