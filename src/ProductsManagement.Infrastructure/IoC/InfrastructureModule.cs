using Autofac;
using Microsoft.Extensions.Configuration;
using ProductsManagement.Infrastructure.IoC.Modules;

namespace ProductsManagement.Infrastructure.IoC;

public class InfrastructureModule : Autofac.Module
{
    private readonly IConfiguration _configuration;

    public InfrastructureModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new MediatrModule());
        builder.RegisterModule(new RepositoryModule());
        builder.RegisterModule(new DatabaseModule(_configuration));
    }
}