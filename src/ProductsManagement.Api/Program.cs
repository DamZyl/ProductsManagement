using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using ProductsManagement.Api.Configurations.Extensions;
using ProductsManagement.Api.Configurations.Validations;
using ProductsManagement.Application.Configurations.Mappers;
using ProductsManagement.Application.Configurations.Validations;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new InfrastructureModule(builder.Configuration));
    });

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddProblemDetails(x =>
{
    x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
    x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseProblemDetails();
    await app.ApplyMigrations(app.Services);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
