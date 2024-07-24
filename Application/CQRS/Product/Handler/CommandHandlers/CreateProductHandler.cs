using Application.CQRS.Product.Command.Request;
using Application.CQRS.Product.Command.Response;
using AutoMapper;
using Common.GlobalExceptionResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Product.Handler.CommandHandlers;
public class CreateProductHandler(IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<CreateProductRequest, ResponseModel<CreateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResponseModel<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var mappedRequest = _mapper.Map<Domain.Entities.Product>(request);
        mappedRequest.CreatedAt = DateTime.Now;
        await _unitOfWork.ProductRepository.AddAsync(mappedRequest);
        await _unitOfWork.SaveChanges();
        var response = _mapper.Map<CreateProductResponse>(mappedRequest);
        return new ResponseModel<CreateProductResponse>(response);
    }
}