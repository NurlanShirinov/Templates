using Application.CQRS.Product.Query.Request;
using Application.CQRS.Product.Query.Response;
using Common.GlobalExceptionResponses.Generics;
using MediatR;
using Repository.Common;
using Domain.Extensions;


namespace Application.CQRS.Product.Handler.QueryHandlers;
public class GetAllProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductRequest, Pagination<GetAllProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Pagination<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(); 
        var totalCount = products.Count();
        products = products.PageBy(request.Page, request.Limit);
        var productList = products.Select(p => new GetAllProductResponse() { Id = p.Id, Name = p.Name, Price = p.Price }).ToList();
        return new Pagination<GetAllProductResponse> {  Data = productList, TotalCount = totalCount , Page = request.Page , Size = request.Limit };
    }
}
