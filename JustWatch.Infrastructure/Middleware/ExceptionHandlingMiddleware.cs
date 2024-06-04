using JustWatch.Application.Common.Responses;
using Microsoft.AspNetCore.Http;
using System.Net;


namespace JustWatch.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate requestDelegate
           )
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var req = httpContext.Request;
                var msg = string.Format("HTTP {0} {1}://{2}{3}", req.Method, req.Scheme, req.Host, req.Path);
                await this._next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (ex is FluentValidation.ValidationException)
                return CreateValidationException(context, ex);
            return context.Response.WriteAsync(Response.Error(ex.Message).ToString());
        }

        private Task CreateValidationException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            var errors = ((FluentValidation.ValidationException)ex).Errors;

            string message = "";

            foreach (var error in errors)
            {
                message += error.ErrorMessage + "\n";
            }
            return context.Response.WriteAsync(Response.Error(message).ToString());

        }
    }
}
