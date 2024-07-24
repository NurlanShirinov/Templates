using Application.CQRS.Product.Command.Request;
using Application.CQRS.Product.Command.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, CreateProductResponse>();
    }
}