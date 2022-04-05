using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Infrastructure.Databases.Sql;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public ProductContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}