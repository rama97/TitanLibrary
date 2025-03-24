using Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace TitanLibrary
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {

        public GlobalExceptionHandler()
        {
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = new ProblemDetails();
            switch (exception)
            {
                case DataNotFoundException dataNotFoundException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Type = dataNotFoundException.GetType().Name,
                        Title = dataNotFoundException.Title,
                        Detail = dataNotFoundException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    break;
                case BadRequestException badRequestException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = badRequestException.GetType().Name,
                        Title = badRequestException.Title,
                        Detail = badRequestException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    break;

                case NotAuthorizedException notAuthorizedException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.Unauthorized,
                        Type = notAuthorizedException.GetType().Name,
                        Title = notAuthorizedException.Title,
                        Detail = notAuthorizedException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    break;
                default:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = exception.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = exception.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                    };
                    break;
            }
            httpContext.Response.StatusCode = result.Status.HasValue ? result.Status.Value : (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
            return true;
        }
    }
}
