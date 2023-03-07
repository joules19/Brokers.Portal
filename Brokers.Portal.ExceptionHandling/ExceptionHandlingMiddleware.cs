using Microsoft.AspNetCore.Http;
using System.Net;

namespace Brokers.Portal.MiddleWares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
            catch (DomainNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (DomainValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync(ex.Message);
			}
        }
    }
}
