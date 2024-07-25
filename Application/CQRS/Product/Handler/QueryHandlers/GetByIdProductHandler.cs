using Application.CQRS.Product.Query.Request;
using Application.CQRS.Product.Query.Response;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalExceptionResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Product.Handler.QueryHandlers;

public class GetByIdProductHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetByIdProductRequest, ResponseModel<GetByIdProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResponseModel<GetByIdProductResponse>> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
    {
        var currentEntity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id) ?? throw new BadRequestException();
        var result = _mapper.Map<GetByIdProductResponse>(currentEntity);
        return new ResponseModel<GetByIdProductResponse>(result);
    }
}