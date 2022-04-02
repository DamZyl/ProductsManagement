using Autofac;
using ProductsManagement.Infrastructure.IoC.Modules;

namespace ProductsManagement.Infrastructure.IoC;

public class InfrastructureModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new MediatrModule());
        builder.RegisterModule(new RepositoryModule());
    }
}