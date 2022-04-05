using FluentAssertions;
using ProductsManagement.Domain.Exceptions;
using ProductsManagement.Domain.Products;
using ProductsManagement.Test.Helpers;
using Xunit;

namespace ProductsManagement.Test;

public class ProductTest
{
    [Fact]
    public void Create_Product_Set_Product_Name_Null_Value()
    {
        // Arrange
        string name = null;
        
        // Act
        var act = () => Product.Create(name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Name is null or white space.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Name_Whitespace()
    {
        // Arrange
        var name = "";
        
        // Act
        var act = () => Product.Create(name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Name is null or white space.");
    }

    [Fact]
    public void Create_Product_Set_Product_Name_Longer_Than_100()
    {
        // Arrange
        var name = $"hNIfG8Z8pgJ2SLV5kjmZZU1xgMKXPJbHDefCUPIqNvCyL8vkMSHWRD54RMH69Of8gfWKpSFHURy5D" + 
                                   $"4QwnJjTA5wlQaBSpkicfT721aDVbBZvH3gkPAL6XCrFy5lJ7TqtgCMMJS5bgkEYyQ52JrOYIQBNGbdn5bNo";

        // Act
        var act = () => Product.Create(name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage($"Name length: { name.Length } so is longer than 100.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Name_Shorter_Than_100()
    {
        // Arrange
        
        // Act
        var act = () => Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Create_Product_Set_Product_Price_Less_Than_0()
    {
        // Arrange
        var price = -1M;
        
        // Act
        var act = () => Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Price is less or equal than 0.");
    }
    
    [Fact]
    public void Create_Product_Set_Product_Price_Equals_0()
    {
        // Arrange
        var price = 0M;
        
        // Act
        var act = () => Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, price);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Price is less or equal than 0.");
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Greater_Than_0()
    {
        // Arrange
        var newQuantity = 20;
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct("", newQuantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Equals_0()
    {
        // Arrange
        var newQquantity = 0;
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct("", newQquantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Less_Than_0()
    {
        // Arrange
        var newQuantity = -1;
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct("", newQuantity);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage("Quantity is less than 0.");
    }
    
    [Fact]
    public void Update_Product_Set_Product_Quantity_Same_Value()
    {
        // Arrange
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct("", ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Null_Value()
    {
        // Arrange
        string newDescription = null;
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct(newDescription, ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Whitespace()
    {
        // Arrange
        var newDescription = "";
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct(newDescription, ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Same_Value()
    {
        // Arrange
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct(ProductHelper.Description, ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Less_Than_200()
    {
        // Arrange
        var newDescription = "Opis2";
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct(newDescription, ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .NotThrow();
    }
    
    [Fact]
    public void Update_Product_Set_Product_Description_Greater_Than_200()
    {
        // Arrange
        var newDescription = $"f3bL8hVYzORvGSAtbcdQZcSB26or65fknYeZnrlaKnayUAQzojkOkpnNi6VZEddJCI5r" + 
                             $"tzl83fEmJ7khO104NZEYXUcEUX1Kme6vmaxcoO97CVrSq5PdF07QR7FbKddwCXtwVnL2XpJ2m" + 
                             $"993FniMxsfjrpoXNCe9NiFf9xeh6YcTiXuKhXpz2DgI7r7lrYYkJrb1E3mjTJnAuLu5bEVszmCBJI80";
        var product = Product.Create(ProductHelper.Name, ProductHelper.Number, ProductHelper.Quantity, ProductHelper.Description, ProductHelper.Price);
        
        // Act
        var act = () => product.UpdateProduct(newDescription, ProductHelper.Quantity);
        
        // Assert
        act.Should()
            .Throw<BusinessRuleValidationException>()
            .WithMessage($"Description length: {newDescription.Length} so is longer than 200.");
    }
}