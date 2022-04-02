using ProductsManagement.Application.Configurations.Dispatchers;

namespace ProductsManagement.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand : ICommand
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
}