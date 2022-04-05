using Microsoft.EntityFrameworkCore;
using ProductsManagement.Infrastructure.Databases.Sql;

namespace ProductsManagement.Api.Configurations.Extensions;

public static class ConfigureExtension
{
    public static async Task ApplyMigrations(this IApplicationBuilder app, IServiceProvider service)
    {
        await using var scope = service.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetService<ProductContext>();
        if (context != null)
        {
            Console.WriteLine("Applying Migration...");
            foreach (var item in context.Database.GetMigrations())
            {
                Console.WriteLine(item);
            }
            await context.Database.MigrateAsync();
        }
    }
}