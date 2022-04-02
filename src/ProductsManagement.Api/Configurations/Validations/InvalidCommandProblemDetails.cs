using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Application.Configurations.Validations;

namespace ProductsManagement.Api.Configurations.Validations;

public class InvalidCommandProblemDetails : ProblemDetails
{
    public InvalidCommandProblemDetails(InvalidCommandException exception)
    {
        Title = exception.Message;
        Status = StatusCodes.Status400BadRequest;
        Detail = exception.Details;
        Type = "https://somedomain/validation-error";
    }
}