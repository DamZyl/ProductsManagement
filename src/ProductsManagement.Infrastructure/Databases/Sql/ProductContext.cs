using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsManagement.Domain.Products;
using ProductsManagement.Infrastructure.Options;

namespace ProductsManagement.Infrastructure.Databases.Sql;

public class ProductContext : DbContext
{
    private readonly IOptions<SqlOption> _sqlOption;

    public DbSet<Product> Products { get; set; }
    
    public ProductContext(DbContextOptions options) : base(options) { }
    
    public ProductContext(IOptions<SqlOption> sqlOption)
    {
        _sqlOption = sqlOption;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        
        optionsBuilder.UseSqlServer(_sqlOption.Value.ConnectionString, 
            options => options.MigrationsAssembly("ProductsManagement.Infrastructure"));
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}