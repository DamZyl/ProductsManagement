using ProductsManagement.Domain.Exceptions;

namespace ProductsManagement.Api.Configurations.Validations;

public class BusinessRuleValidationExceptionProblemDetails: Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
    {
        Title = exception.Message;
        Status = StatusCodes.Status409Conflict;
        Detail = exception.Details;
        Type = "https://somedomain/business-rule-validation-error";
    }
}