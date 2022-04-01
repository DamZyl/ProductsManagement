namespace ProductsManagement.Domain.Exceptions.Rules;

public class GreaterThanZeroRule<T> : IBusinessRule where T : struct 
{
    private readonly T _property;

    public GreaterThanZeroRule(T property)
    {
        _property = property;
    }

    public bool IsBroken() => (dynamic)_property <= 0;

    public string Message => $"{nameof(_property)} is less or equal than 0";
}