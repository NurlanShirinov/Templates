using Application.CQRS.Product.Query.Response;
using Common.GlobalExceptionResponses.Generics;
using MediatR;

namespace Application.CQRS.Product.Query.Request;
public class GetAllProductRequest : IRequest<Pagination<GetAllProductResponse>>
{
    public int Page { get; set; }
    public int Limit { get; set; }

    public GetAllProductRequest()
    {
        Page = 1;
        Limit = 10;
    }

    public GetAllProductRequest(int page, int limit)
    {
        Page = page;
        Limit = limit;
    }
}