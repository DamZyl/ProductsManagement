using ProductsManagement.Application.Configurations.Dispatchers;
using ProductsManagement.Domain.Products;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductViewModel>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CreateProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Number, request.Quantity, request.Description,
            request.Price);

        await _productRepository.AddAsync(product);

        return new CreateProductViewModel { Id = product.Id };
    }
}