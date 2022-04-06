using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Products;
using ProductsManagement.Infrastructure.Databases.Sql;

namespace ProductsManagement.Test.Helpers;

public static class DatabaseHelper
{
    public static void InitializeMockDatabase(ProductContext context)
    {
        var mockProduct = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, 
            ProductHelper.Description, ProductHelper.Price);
        context.Products.Add(mockProduct);
        context.SaveChanges();
    }
    
    public static DbContextOptions<T> ConfigureDatabaseOptions<T>(string databaseName) where T : DbContext
        => new DbContextOptionsBuilder<T>().UseInMemoryDatabase(databaseName: databaseName).Options;

    public static Product GetMockProduct(ProductContext context)
        => context.Products.First();
}