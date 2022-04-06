using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using ProductsManagement.Application.Extensions;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Domain.Products;
using ProductsManagement.Infrastructure.Databases.Sql;
using ProductsManagement.Infrastructure.Repositories;
using ProductsManagement.Test.Helpers;
using Xunit;

namespace ProductsManagement.Test;

public class RepositoryTest
{
    private readonly ProductContext _context;
    private readonly Product _mockProduct;

    public RepositoryTest()
    {
        _context = new ProductContext(DatabaseHelper.ConfigureDatabaseOptions<ProductContext>("ProductsInMemory"));
        DatabaseHelper.InitializeMockDatabase(_context);
        _mockProduct = DatabaseHelper.GetMockProduct(_context);
    }
    
    [Fact]
    public async Task Get_Or_Fail_By_Id_Async_Return_Product()
    {
        // Arrange
        var productRepository = new ProductRepository(_context);
        
        // Act
        var product = await productRepository.GetOrFailByIdAsync(_mockProduct.Id);

        // Assert
        product.Should()
            .NotBeNull()
            .And
            .BeAssignableTo<Product>();
    }
    
    [Fact]
    public async Task Get_Or_Fail_By_Id_Async_Throw_Exception()
    {
        // Arrange
        var productRepository = new ProductRepository(_context);
        
        // Act
        var act = () => productRepository.GetOrFailByIdAsync(new Guid("2ab7aae9-b45b-4a27-b718-6de82b8f1794"));

        // Assert
        await act.Should()
            .ThrowAsync<BusinessRuleValidationException>()
            .WithMessage("Product with id: '2ab7aae9-b45b-4a27-b718-6de82b8f1794' does not exist.");
    }
    
    [Fact]
    public async Task Get_All_Async_Return_Products()
    {
        // Arrange
        var productRepository = new ProductRepository(_context);
        
        // Act
        var products = await productRepository.GetAllAsync();

        // Assert
        products.Should()
            .NotBeNullOrEmpty()
            .And
            .BeAssignableTo<IEnumerable<Product>>();
    }
    
    [Fact]
    public async Task Create_Product_With_Correct_Data()
    {
        // Arrange
        var mockProduct = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, 
            ProductHelper.Description, ProductHelper.Price);
        var productRepository = new ProductRepository(_context);
        
        // Act
       var act = () => productRepository.AddAsync(mockProduct);

       // Assert
       await act.Should()
           .NotThrowAsync();
    }
    
    [Fact]
    public async Task Update_Product_With_Correct_Data()
    {
        // Arrange
        var productRepository = new ProductRepository(_context);
        _mockProduct.UpdateProduct("Opis2", 20);
        
        // Act
        await productRepository.EditAsync(_mockProduct);

        // Assert
        _mockProduct.As<Product>()
            .Description
            .Should()
            .Be("Opis2");
        _mockProduct.As<Product>()
            .Quantity
            .Should()
            .Be(20);
    }
    
    [Fact]
    public async Task Delete_Product_With_Correct_Data()
    {
        // Arrange
        var productRepository = new ProductRepository(_context);
        
        // Act
        var act = () => productRepository.DeleteAsync(_mockProduct);

        // Assert
        await act.Should()
            .NotThrowAsync();
    }
}