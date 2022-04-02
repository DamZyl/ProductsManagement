using ProductsManagement.Application.Products.Queries.GetProducts;

namespace ProductsManagement.Application.Products.Queries.GetProduct;

public class ProductDetailViewModel : ProductViewModel
{
    public int Number { get; set; }
    public string Description { get; set; }
}