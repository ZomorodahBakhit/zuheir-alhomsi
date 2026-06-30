using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using University.Core.Exceptions;

namespace University.Api.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case NotFoundException notFoundEx:
                context.Result = new NotFoundObjectResult(new
                {
                    error = "Not Found",
                    message = notFoundEx.Message,
                    statusCode = 404
                });
                context.ExceptionHandled = true;
                break;

            case BusinessException businessEx:
                context.Result = new BadRequestObjectResult(new
                {
                    error = "Bad Request",
                    message = businessEx.Message,
                    statusCode = 400
                });
                context.ExceptionHandled = true;
                break;

            default:
                context.Result = new ObjectResult(new
                {
                    error = "Internal Server Error",
                    message = "An unexpected error occurred on the server.",
                    statusCode = 500
                })
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
                break;
        }
    }
}