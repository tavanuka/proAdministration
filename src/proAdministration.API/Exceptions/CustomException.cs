using System.Net;

namespace proAdministration.API.Exceptions;

public class CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    : ApplicationException(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}