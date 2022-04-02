using MediatR;
using ProductsManagement.Application.Configurations.Dispatchers;
using ProductsManagement.Application.Extensions;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetOrFailByIdAsync(request.Id);
        product.UpdateProduct(request.Description, request.Quantity);
        
        await _productRepository.EditAsync(product);

        return Unit.Value;
    }
}