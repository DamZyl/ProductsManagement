using ProductsManagement.Domain.Products;

namespace ProductsManagement.Domain.Repositories;

public interface IProductRepository : IRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task EditAsync(Product product);
    Task DeleteAsync(Product product);
}