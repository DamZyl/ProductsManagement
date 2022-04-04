namespace ProductsManagement.Domain.Exceptions.Rules;

public class NullOrWhiteSpaceRule : IBusinessRule
{
    private readonly string _property;
    private readonly string _propertyName;

    public NullOrWhiteSpaceRule(string property, string propertyName)
    {
        _property = property;
        _propertyName = propertyName;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_property);

    public string Message => $"{ _propertyName } is null or white space.";
}