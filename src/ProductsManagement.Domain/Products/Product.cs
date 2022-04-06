using ProductsManagement.Domain.Exceptions.Rules;
using ProductsManagement.Domain.Helpers;

namespace ProductsManagement.Domain.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Number { get; private set; }
    public int Quantity { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    private Product() { }

    private Product(string name, int number, int quantity, string description, decimal price)
    {
        Id = Guid.NewGuid();
        SetName(name);
        SetPrice(price);
        Number = number;
        Quantity = quantity;
        Description = description;
    }

    public static Product Create(string name, int number, int quantity, string description, decimal price) =>
        new(name, number, quantity, description, price);

    public void UpdateProduct(string description, int quantity)
    {
        SetDescription(description);
        SetQuantity(quantity);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Product product)
        {
            return false;
        }

        return Id.Equals(product.Id) 
               && Name.Equals(product.Name) 
               && Number.Equals(product.Number);
    }
    
    public override int GetHashCode() =>  HashCode.Combine(Id, Name, Number);
    
    #region Setters

    private void SetName(string name)
    {
        ExceptionHelper.CheckRule(new NullOrWhiteSpaceRule(name, nameof(Name)));
        ExceptionHelper.CheckRule(new LengthRule(name, nameof(Name), 100));
        Name = name;
    }
    
    private void SetQuantity(int quantity)
    {
        if (Quantity == quantity)
        {
            return;
        }
        
        ExceptionHelper.CheckRule(new LessThanZeroRule<int>(quantity, nameof(Quantity)));
        Quantity = quantity;
    }
    
    private void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || Description == description)
        {
            return;
        }
        
        ExceptionHelper.CheckRule(new LengthRule(description, nameof(Description), 200));
        Description = description;
    }

    private void SetPrice(decimal price)
    {
        ExceptionHelper.CheckRule(new GreaterThanZeroRule<decimal>(price, nameof(Price)));
        Price = price;
    }

    #endregion
}