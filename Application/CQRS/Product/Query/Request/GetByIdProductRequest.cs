using Application.CQRS.Product.Query.Response;
using Common.GlobalExceptionResponses.Generics;
using MediatR;

namespace Application.CQRS.Product.Query.Request;

public class GetByIdProductRequest : IRequest<ResponseModel<GetByIdProductResponse>>
{
    public int Id { get; set; }

    public GetByIdProductRequest(int id)
    {
        Id = id;
    }
}
