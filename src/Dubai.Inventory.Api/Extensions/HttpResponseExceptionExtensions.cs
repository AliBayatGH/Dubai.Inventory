using Dubai.Inventory.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Dubai.Inventory.Api.Extensions;

public static class HttpResponseExceptionExtensions
{
    public static ValidationProblemDetails ToProblemDetails(this HttpResponseException ex,int statusCode= StatusCodes.Status400BadRequest)
    {
        var problemDetails = new ValidationProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred.",
            Status = statusCode,
        };
        problemDetails.Errors.Add(ex.StatusCode.ToString(), new[] { ex.Message });
        return problemDetails;
    }
}
