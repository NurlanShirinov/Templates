namespace Application.CQRS.Product.Query.Response;

public class GetByIdProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}
