namespace ProductsManagement.Domain.Exceptions.Rules;

public class LengthRule : IBusinessRule
{
    private readonly string _property;
    private readonly string _propertyName;
    private readonly int _length;
    
    public LengthRule(string property, string propertyName, int length)
    {
        _property = property;
        _propertyName = propertyName;
        _length = length;
    }

    public bool IsBroken() => _property.Length > _length;
    public string Message => $"{ _propertyName } length: { _property.Length } so is longer than { _length }.";
}