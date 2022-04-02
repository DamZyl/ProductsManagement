using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Api.Products.Requests;
using ProductsManagement.Application.Products.Commands.CreateProduct;
using ProductsManagement.Application.Products.Commands.DeleteProduct;
using ProductsManagement.Application.Products.Commands.UpdateProduct;
using ProductsManagement.Application.Products.Queries.GetProduct;
using ProductsManagement.Application.Products.Queries.GetProducts;

namespace ProductsManagement.Api.Products;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Route("")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());

        return Ok(products);
    }
        
    [Route("{id:guid}")]
    [HttpGet]
    [ProducesResponseType(typeof(ProductDetailViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _mediator.Send(new GetProductQuery { Id = id });

        return Ok(product);
    }
    
    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(CreateProductViewModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request) 
    {
        var product = await _mediator.Send(new CreateProductCommand(request.Name, 
            request.Number, request.Quantity, request.Description, request.Price));

        return Created(string.Empty, product);
    }
    
    [Route("{id:guid}")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody]UpdateProductRequest request)
    {
        await _mediator.Send(new UpdateProductCommand(id, request.Description, request.Quantity));

        return NoContent();
    }
        
    [Route("{id:guid}")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}