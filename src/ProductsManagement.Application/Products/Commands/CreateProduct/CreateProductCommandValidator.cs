using FluentValidation;

namespace ProductsManagement.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name lenght is greater than 100.");

        RuleFor(x => x.Description)
            .MaximumLength(200)
            .WithMessage("Description is greater than 200.");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required.");
    }
}