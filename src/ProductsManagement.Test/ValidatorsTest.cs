using System;
using FluentAssertions;
using FluentValidation.TestHelper;
using ProductsManagement.Api.Products.Requests;
using ProductsManagement.Application.Products.Commands.CreateProduct;
using ProductsManagement.Application.Products.Commands.UpdateProduct;
using ProductsManagement.Test.Helpers;
using Xunit;

namespace ProductsManagement.Test;

public class ValidatorsTest
{
    [Fact]
    public void Create_Product_Validator_With_Correct_Data()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = ProductHelper.Name,
            Number = ProductHelper.Number,
            Quantity = ProductHelper.Quantity,
            Description = ProductHelper.Description,
            Price = ProductHelper.Price
        };
        var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
            request.Description,request.Price);
        var validator = new CreateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(c => c);
    }
    
    [Fact]
    public void Create_Product_Validator_With_Null_Name_Value_Return_Error()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = null,
            Number = ProductHelper.Number,
            Quantity = ProductHelper.Quantity,
            Description = ProductHelper.Description,
            Price = ProductHelper.Price
        };
        var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
            request.Description,request.Price);
        var validator = new CreateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name is required.");
    }
    
    [Fact]
    public void Create_Product_Validator_With_Whitespace_Name_Value_Return_Error()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "",
            Number = ProductHelper.Number,
            Quantity = ProductHelper.Quantity,
            Description = ProductHelper.Description,
            Price = ProductHelper.Price
        };
        var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
            request.Description,request.Price);
        var validator = new CreateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name is required.");
    }
    
    [Fact]
    public void Create_Product_Validator_With_Name_Greater_Than_100_Return_Error()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = $"hNIfG8Z8pgJ2SLV5kjmZZU1xgMKXPJbHDefCUPIqNvCyL8vkMSHWRD54RMH69Of8gfWKpSFHURy5D" + 
                   $"4QwnJjTA5wlQaBSpkicfT721aDVbBZvH3gkPAL6XCrFy5lJ7TqtgCMMJS5bgkEYyQ52JrOYIQBNGbdn5bNo",
            Number = ProductHelper.Number,
            Quantity = ProductHelper.Quantity,
            Description = ProductHelper.Description,
            Price = ProductHelper.Price
        };
        var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
            request.Description,request.Price);
        var validator = new CreateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name lenght is greater than 100.");
    }
    
    [Fact]
    public void Create_Product_Validator_Without_Price_Value_Return_Error()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = ProductHelper.Name,
            Number = ProductHelper.Number,
            Quantity = ProductHelper.Quantity,
            Description = ProductHelper.Description
        };
        var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
            request.Description, request.Price);
        var validator = new CreateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price is required.");
    }
    
    [Fact]
    public void Update_Product_Validator_With_Correct_Data()
    {
        // Arrange
        var request = new UpdateProductRequest
        {
            Description = ProductHelper.Description,
            Quantity = ProductHelper.Quantity
        };
        var command = new UpdateProductCommand(Guid.NewGuid(), request.Description, request.Quantity);
        var validator = new UpdateProductCommandValidator();

        // Act
        var result = validator.TestValidate(command);
        
        // Assert
        result.ShouldNotHaveValidationErrorFor(c => c);
    }
    
    // [Fact]
    // public void Update_Product_Validator_Without_Id_Return_Error()
    // {
    //     // Arrange
    //     var request = new CreateProductRequest
    //     {
    //         Name = null,
    //         Number = ProductHelper.Number,
    //         Quantity = ProductHelper.Quantity,
    //         Description = ProductHelper.Description,
    //         Price = ProductHelper.Price
    //     };
    //     var command = new CreateProductCommand(request.Name, request.Number, request.Quantity, 
    //         request.Description,request.Price);
    //     var validator = new CreateProductCommandValidator();
    //
    //     // Act
    //     var result = validator.TestValidate(command);
    //     
    //     // Assert
    //     result.ShouldHaveValidationErrorFor(x => x.Name)
    //         .WithErrorMessage("Name is required.");
    // }
}