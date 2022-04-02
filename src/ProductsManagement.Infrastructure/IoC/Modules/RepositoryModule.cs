using Autofac;
using ProductsManagement.Domain.Repositories;
using System.Reflection;

namespace ProductsManagement.Infrastructure.IoC.Modules;

public class RepositoryModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(RepositoryModule)
            .GetTypeInfo()
            .Assembly;

        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.IsAssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}