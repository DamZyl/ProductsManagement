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
        SetNumber(number);
        SetQuantity(quantity);
        SetDescription(description);
        SetPrice(price);
    }

    public static Product Create(string name, int number, int quantity, string description, decimal price) =>
        new(name, number, quantity, description, price);

    #region Setters

    private void SetName(string name)
    {
        ExceptionHelper.CheckRule(new NullOrWhiteSpaceRule(name));
        ExceptionHelper.CheckRule(new LengthRule(name, 100));
        Name = name;
    }

    private void SetNumber(int number)
    {
        ExceptionHelper.CheckRule(new GreaterThanZeroRule<int>(number));
        Number = number;
    }
    
    private void SetQuantity(int quantity)
    {
        ExceptionHelper.CheckRule(new GreaterThanZeroRule<int>(quantity));
        Quantity = quantity;
    }
    
    private void SetDescription(string description)
    {
        ExceptionHelper.CheckRule(new NullOrWhiteSpaceRule(description));
        ExceptionHelper.CheckRule(new LengthRule(description, 200));
        Description = description;
    }

    private void SetPrice(decimal price)
    {
        ExceptionHelper.CheckRule(new GreaterThanZeroRule<decimal>(price));
        Price = price;
    }

    #endregion
}