using ProductsManagement.Domain.Products;

namespace ProductsManagement.Domain.Exceptions.Rules;

public class ProductDoesNotExist : IBusinessRule
{
    private readonly Guid _id;
    private readonly Product _product;

    public ProductDoesNotExist(Guid id, Product product)
    {
        _id = id;
        _product = product;
    }

    public bool IsBroken() => _product == null;

    public string Message => $"Product with id: '{ _id }' does not exist.";
}