using MediatR;
using ProductsManagement.Application.Configurations.Dispatchers;
using ProductsManagement.Application.Extensions;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetOrFailByIdAsync(request.Id);

        await _productRepository.DeleteAsync(product);
        
        return Unit.Value;
    }
}