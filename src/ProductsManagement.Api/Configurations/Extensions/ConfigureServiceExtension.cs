namespace ProductsManagement.Api.Configurations.Extensions;

public static class ConfigureServiceExtension
{
    public static void ConfigureOption<T>(this IServiceCollection services, IConfiguration configuration, string section) where T : class
        => services.Configure<T>(x => configuration.GetSection(section).Bind(x));
}