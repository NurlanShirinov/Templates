using Application.CQRS.Product.Command.Response;
using MediatR;
using Common.GlobalExceptionResponses.Generics;

namespace Application.CQRS.Product.Command.Request;
public class UpdateProductRequest : IRequest<ResponseModel<UpdateProductResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}