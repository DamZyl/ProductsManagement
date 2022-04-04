using ProductsManagement.Domain.Exceptions.Rules;
using ProductsManagement.Domain.Helpers;
using ProductsManagement.Domain.Products;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Extensions;

public static class RepositoryExtension
{
    public static async Task<Product> GetOrFailByIdAsync(this IProductRepository repository, Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        ExceptionHelper.CheckRule(new ProductDoesNotExist(id, product));

        return product;
    }

}