namespace ProductsManagement.Domain.Exceptions.Rules;

public class NullOrWhiteSpaceRule : IBusinessRule
{
    private readonly string _property;

    public NullOrWhiteSpaceRule(string property)
    {
        _property = property;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_property);

    public string Message => $"{ nameof(_property) } is null or white space.";
}