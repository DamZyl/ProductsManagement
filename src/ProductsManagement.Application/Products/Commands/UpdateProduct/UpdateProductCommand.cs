using ProductsManagement.Application.Configurations.Dispatchers;

namespace ProductsManagement.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand : ICommand
{
    public Guid Id { get; }
    public string Description { get; }
    public int Quantity { get; }

    public UpdateProductCommand(Guid id, string description, int quantity)
    {
        Id = id;
        Description = description;
        Quantity = quantity;
    }
}