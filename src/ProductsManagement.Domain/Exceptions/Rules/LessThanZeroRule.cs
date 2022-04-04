namespace ProductsManagement.Domain.Exceptions.Rules;

public class LessThanZeroRule<T> : IBusinessRule where T : struct 
{
    private readonly T _property;
    private readonly string _propertyName;

    public LessThanZeroRule(T property, string propertyName)
    {
        _property = property;
        _propertyName = propertyName;
    }

    public bool IsBroken() => (dynamic)_property < 0;

    public string Message => $"{ _propertyName } is less than 0";
}