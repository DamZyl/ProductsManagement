namespace ProductsManagement.Api.Products.Requests;

public class UpdateProductRequest
{
    public string? Description { get; set; }
    public int Quantity { get; set; }
}