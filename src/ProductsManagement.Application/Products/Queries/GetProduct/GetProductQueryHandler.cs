using AutoMapper;
using ProductsManagement.Application.Configurations.Dispatchers;
using ProductsManagement.Application.Extensions;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetOrFailByIdAsync(request.Id);

        return _mapper.Map<ProductDetailViewModel>(product);
    }
}