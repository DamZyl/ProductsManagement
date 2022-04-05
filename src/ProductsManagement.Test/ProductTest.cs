using FluentAssertions;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Domain.Products;
using Xunit;

namespace ProductsManagement.Test;

public class ProductTest
{
    [Fact]
    public void Set_Product_Name_Longer_Than_100()
    {
        // Arrange
        var productName = $"hNIfG8Z8pgJ2SLV5kjmZZU1xgMKXPJbHDefCUPIqNvCyL8vkMSHWRD54RMH69Of8gfWKpSFHURy5D" + 
                                   $"4QwnJjTA5wlQaBSpkicfT721aDVbBZvH3gkPAL6XCrFy5lJ7TqtgCMMJS5bgkEYyQ52JrOYIQBNGbdn5bNo";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage($"Name length: {productName.Length} so is longer than 100.");
    }
    
    [Fact]
    public void Set_Product_Name_Shorter_Than_100()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .NotThrow();;
    }
    
    [Fact]
    public void Set_Product_Price_Less_Than_0()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = -1M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Price is less or equal than 0");
    }
    
    [Fact]
    public void Set_Product_Price_Equals_0()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 0M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Price is less or equal than 0");
    }
}