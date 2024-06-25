using System.Net;

namespace proAdministration.API.Exceptions;

public class NotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
    : CustomException(message, statusCode);