using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.Api.Configurations.Extensions;
using ProductsManagement.Api.Configurations.Validations;
using ProductsManagement.Application.Configurations.Validations;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Infrastructure.Databases.Sql;
using ProductsManagement.Infrastructure.IoC;
using ProductsManagement.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(x =>
    {
        x.RegisterModule(new InfrastructureModule());
    });

builder.Services.ConfigureOption<SqlOption>(builder.Configuration, "Sql");
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails(x =>
{
    x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
    x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseProblemDetails();
}

await using var scope = app.Services.CreateAsyncScope();
await using var context = scope.ServiceProvider.GetService<ProductContext>();
if (context != null) await context.Database.MigrateAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
