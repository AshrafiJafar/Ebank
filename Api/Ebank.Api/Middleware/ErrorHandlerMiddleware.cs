using Framework.Domain.Exception;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System.Text;

namespace Ebank.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;


        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var Result = "";
            var message = "";
            
            if (exception is DomainException)
            {
                httpContext.Response.StatusCode = 450;
                httpContext.Response.ContentType = "text/plain";
                message = exception.Message;
            }
            else
            {
                message = "خطای مدیریت نشده!";
            }
            Result = JsonConvert.SerializeObject(new ExceptionModel(httpContext.Response.StatusCode, message));

            return httpContext.Response.WriteAsync(Result);
        }
    }

    
}
