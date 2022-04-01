using ProductsManagement.Domain.Exceptions;

namespace ProductsManagement.Domain.Helpers;

public static class ExceptionHelper
{
    public static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}