using AutoMapper;
using ProductsManagement.Application.Configurations.Dispatchers;
using ProductsManagement.Domain.Repositories;

namespace ProductsManagement.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ProductViewModel>>(products);
    }
}