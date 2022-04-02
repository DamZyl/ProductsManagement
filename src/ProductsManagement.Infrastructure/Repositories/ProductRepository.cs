using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Products;
using ProductsManagement.Domain.Repositories;
using ProductsManagement.Infrastructure.Databases.Sql;

namespace ProductsManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    // add pagination later!!!
    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    // add repository extension later GetOrFailAsync(this repo, Guid id)!!!
    public async Task<Product> GetByIdAsync(Guid id)
        => await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}