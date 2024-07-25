using Application.CQRS.Product.Command.Request;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Product.Handler.CommandHandlers;
public class DeleteProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        _unitOfWork.ProductRepository.Delete(request.Id);
        await _unitOfWork.SaveChanges();
       
    }
}