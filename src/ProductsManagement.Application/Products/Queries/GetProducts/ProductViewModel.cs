namespace ProductsManagement.Application.Products.Queries.GetProducts;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}