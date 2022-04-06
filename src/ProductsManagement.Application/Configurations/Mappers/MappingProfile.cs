using AutoMapper;
using ProductsManagement.Application.Products.Queries.GetProduct;
using ProductsManagement.Application.Products.Queries.GetProducts;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Application.Configurations.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>();
        CreateMap<Product, ProductDetailViewModel>();
    }
}