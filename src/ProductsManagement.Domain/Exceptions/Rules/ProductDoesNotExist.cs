using ProductsManagement.Domain.Products;

namespace ProductsManagement.Domain.Exceptions.Rules;

public class ProductDoesNotExist : IBusinessRule
{
    private readonly Product _product;

    public ProductDoesNotExist(Product product)
    {
        _product = product;
    }

    public bool IsBroken() => _product == null;

    public string Message => $"Product with id: '{_product.Id}' does not exist.";
}