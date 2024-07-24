using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    Task SaveChanges();
}
