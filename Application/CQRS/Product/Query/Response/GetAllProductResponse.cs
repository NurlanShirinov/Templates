namespace Application.CQRS.Product.Query.Response;

public class GetAllProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}