using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Moq;
using ProductsManagement.Application.Products.Commands.CreateProduct;
using ProductsManagement.Application.Products.Commands.DeleteProduct;
using ProductsManagement.Application.Products.Commands.UpdateProduct;
using ProductsManagement.Application.Products.Queries.GetProduct;
using ProductsManagement.Application.Products.Queries.GetProducts;
using ProductsManagement.Domain.Products;
using ProductsManagement.Domain.Repositories;
using Xunit;

namespace ProductsManagement.Test;

public class HandlersTest
{
    [Fact]
    public async Task Get_Product_Query_Handler_With_Validate_Result()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var repository = fixture.Freeze<Mock<IProductRepository>>();
        repository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .Returns(Task.FromResult(fixture.Create<Product>()));
        var sut = fixture.Create<GetProductQueryHandler>();
        
        // Act
        var result = await sut.Handle(fixture.Create<GetProductQuery>(), CancellationToken.None);
        
        // Assert
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<ProductDetailViewModel>();
    }
    
    [Fact]
    public async Task Get_Products_Query_Handler_With_Validate_Result()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var repository = fixture.Freeze<Mock<IProductRepository>>();
        repository.Setup(r => r.GetAllAsync())
            .Returns(Task.FromResult(fixture.CreateMany<Product>()));
        var sut = fixture.Create<GetProductsQueryHandler>();
        
        // Act
        var result = await sut.Handle(fixture.Create<GetProductsQuery>(), CancellationToken.None);
        
        // Assert
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<IEnumerable<ProductViewModel>>();
    }
    
    [Fact]
    public async Task Create_Product_Command_Handler_With_Validate_Result()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var repository = fixture.Freeze<Mock<IProductRepository>>();
        repository.Setup(r => r.AddAsync(fixture.Create<Product>()));
        var sut = fixture.Create<CreateProductCommandHandler>();
        
        // Act
        var result = await sut.Handle(fixture.Create<CreateProductCommand>(), CancellationToken.None);
        
        // Assert
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<CreateProductViewModel>();
    }
    
    [Fact]
    public async Task Update_Product_Command_Handler_With_Validate_Result()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var repository = fixture.Freeze<Mock<IProductRepository>>();
        repository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .Returns(Task.FromResult(fixture.Create<Product>()));
        repository.Setup(r => r.EditAsync(fixture.Create<Product>()));
        var sut = fixture.Create<UpdateProductCommandHandler>();
        
        // Act
        var result = await sut.Handle(fixture.Create<UpdateProductCommand>(), CancellationToken.None);
        
        // Assert
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<Unit>();
    }
    
    [Fact]
    public async Task Delete_Product_Command_Handler_With_Validate_Result()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var repository = fixture.Freeze<Mock<IProductRepository>>();
        repository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .Returns(Task.FromResult(fixture.Create<Product>()));
        repository.Setup(r => r.DeleteAsync(fixture.Create<Product>()));
        var sut = fixture.Create<DeleteProductCommandHandler>();
        
        // Act
        var result = await sut.Handle(fixture.Create<DeleteProductCommand>(), CancellationToken.None);
        
        // Assert
        result.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<Unit>();
    }
}