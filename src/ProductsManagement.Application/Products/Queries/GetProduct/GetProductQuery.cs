using ProductsManagement.Application.Configurations.Dispatchers;

namespace ProductsManagement.Application.Products.Queries.GetProduct;

public class GetProductQuery : IQuery<ProductDetailViewModel>
{
    public Guid Id { get; set; }    
}