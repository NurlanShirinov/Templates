using Application.CQRS.Product.Command.Request;
using Application.CQRS.Product.Command.Response;
using Application.CQRS.Product.Query.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, CreateProductResponse>();
        CreateMap<Product, GetByIdProductResponse>();
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, UpdateProductResponse>();
    }
}