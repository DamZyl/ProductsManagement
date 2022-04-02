namespace ProductsManagement.Api.Products.Requests;

public class CreateProductRequest
{
    public string Name { get; set; }
    public int Number { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}