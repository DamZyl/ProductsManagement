namespace ProductsManagement.Domain.Exceptions.Rules;

public class LengthRule : IBusinessRule
{
    private readonly string _property;
    private readonly int _length;

    public LengthRule(string property, int length)
    {
        _property = property;
        _length = length;
    }

    public bool IsBroken() => _property.Length > _length;
    public string Message => $"{ nameof(_property) } length: { _property.Length } so is longer than { _length }.";
}