using Domain.Entities;

namespace Repository.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task Delete(int id);
    Task Update(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync(); 
}
