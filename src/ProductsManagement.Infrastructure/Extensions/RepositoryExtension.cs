using ProductsManagement.Domain.Products;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Infrastructure.Extensions;

public static class RepositoryExtension
{
    public static async Task<Product> GetOrFailByIdAsync(this IProductRepository repository, Guid id)
    {
        var product = await repository.GetByIdAsync(id);

        // Refactor to BusinessRule!!!
        if (product == null)
        {
            throw new Exception($"Product with id: '{id}' does not exist.");
        }

        return product;
    }

}