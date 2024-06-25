using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace proAdministration.API.Exceptions;

public static class ExceptionExtensions
{
    public static IActionResult ToResponse(this Exception exception)
    {
        if (exception is not CustomException && exception.InnerException != null)
        {
            exception = exception.InnerException;
        }

        return exception switch
        {
            CustomException customException => new ObjectResult(customException.Message)
                { StatusCode = (int)customException.StatusCode },
            ValidationException validationException => new ObjectResult(validationException.Message)
                { StatusCode = (int)HttpStatusCode.BadRequest },
            _ => new ObjectResult(exception.Message) { StatusCode = (int)HttpStatusCode.InternalServerError }
        };
    }
}