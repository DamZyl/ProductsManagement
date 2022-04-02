using FluentValidation;

namespace ProductsManagement.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductId is required");
        
        RuleFor(x => x.Description)
            .MaximumLength(200)
            .WithMessage("Description is greater than 200.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Quantity should be greater or equal than 0.");
    }
}