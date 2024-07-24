using Application.CQRS.Product.Command.Response;
using Common.GlobalExceptionResponses.Generics;
using MediatR;

namespace Application.CQRS.Product.Command.Request;
public class CreateProductRequest : IRequest<ResponseModel<CreateProductResponse>>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}