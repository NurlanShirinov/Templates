using Application.CQRS.Product.Command.Request;
using Application.CQRS.Product.Command.Response;
using AutoMapper;
using Common.GlobalExceptionResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Product.Handler.CommandHandlers;

public class UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateProductRequest, ResponseModel<UpdateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResponseModel<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var mappedEntity = _mapper.Map<Domain.Entities.Product>(request);
        _unitOfWork.ProductRepository.Update(mappedEntity);
        await _unitOfWork.SaveChanges();
        var response = _mapper.Map<UpdateProductResponse>(mappedEntity);
        return new ResponseModel<UpdateProductResponse>(response);
    }
}