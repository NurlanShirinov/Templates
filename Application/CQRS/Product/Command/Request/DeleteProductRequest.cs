using MediatR;

namespace Application.CQRS.Product.Command.Request;

public class DeleteProductRequest : IRequest
{
    public int Id { get; set; }

    public DeleteProductRequest(int id)
    {
        Id = id;    
    }
    public DeleteProductRequest()
    {

    }
}