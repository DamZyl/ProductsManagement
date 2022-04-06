using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductsManagement.Infrastructure.Databases.Sql;

namespace ProductsManagement.Infrastructure.IoC.Modules;

public class DatabaseModule : Autofac.Module
{
    private readonly IConfiguration _configuration;

    public DatabaseModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        var databaseConnectionString = _configuration.GetSection("Sql")
            .GetSection("ConnectionString")
            .Value;
        
        builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductContext>();
                dbContextOptionsBuilder.UseSqlServer(databaseConnectionString, 
                    opt => opt.MigrationsAssembly("ProductsManagement.Infrastructure"));

                return new ProductContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .As<ProductContext>()
            .InstancePerLifetimeScope();
    }
}