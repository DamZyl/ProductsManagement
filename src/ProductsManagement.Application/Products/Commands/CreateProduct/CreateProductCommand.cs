using ProductsManagement.Application.Configurations.Dispatchers;

namespace ProductsManagement.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : ICommand<CreateProductViewModel>
{
    public string Name { get; }
    public int Number { get; }
    public int Quantity { get; }
    public string Description { get; }
    public decimal Price { get; }

    public CreateProductCommand(string name, int number, int quantity, string description, decimal price)
    {
        Name = name;
        Number = number;
        Quantity = quantity;
        Description = description;
        Price = price;
    }
}