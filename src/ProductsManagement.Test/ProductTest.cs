using FluentAssertions;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Domain.Products;
using Xunit;

namespace ProductsManagement.Test;

public class ProductTest
{
    [Fact]
    public void Create_Product_Set_Product_Name_Null_Value()
    {
        // Arrange
        string productName = null;
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Name is null or white space.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Name_Whitespace()
    {
        // Arrange
        var productName = "";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        
        // Act
        var act = () => Product.Create(productName, number, quantity, description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Name is null or white space.");
    }

    [Fact]
    public void Create_Product_Set_Product_Name_Longer_Than_100()
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
            .WithMessage($"Name length: { productName.Length } so is longer than 100.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Name_Shorter_Than_100()
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
            .NotThrow();
    }
    
    [Fact]
    public void Create_Product_Set_Product_Price_Less_Than_0()
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
            .WithMessage("Price is less or equal than 0.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Price_Equals_0()
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
            .WithMessage("Price is less or equal than 0.");
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Greater_Than_0()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("", 20);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Equals_0()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("", 0);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Less_Than_0()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("", -1);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Quantity is less than 0.");
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Same_Value()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("", quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Null_Value()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct(null, quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Whitespace()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("", quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Same_Value()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct(description, quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Less_Than_200()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        
        // Act
        var act = () => product.UpdateProduct("Opis2", quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Greater_Than_200()
    {
        // Arrange
        var productName = "Nazwa";
        var number = 1;
        var quantity = 10;
        var description = "Opis";
        var price = 20.0M;
        var product = Product.Create(productName, number, quantity, description, price);
        var newDescription = $"f3bL8hVYzORvGSAtbcdQZcSB26or65fknYeZnrlaKnayUAQzojkOkpnNi6VZEddJCI5r" + 
                             $"tzl83fEmJ7khO104NZEYXUcEUX1Kme6vmaxcoO97CVrSq5PdF07QR7FbKddwCXtwVnL2XpJ2m" + 
                             $"993FniMxsfjrpoXNCe9NiFf9xeh6YcTiXuKhXpz2DgI7r7lrYYkJrb1E3mjTJnAuLu5bEVszmCBJI80";
        
        // Act
        var act = () => product.UpdateProduct(newDescription, quantity);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage($"Description length: {newDescription.Length} so is longer than 200.");
    }
}