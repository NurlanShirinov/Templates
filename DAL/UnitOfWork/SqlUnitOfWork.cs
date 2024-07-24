using DAL.Context;
using DAL.Infrastructure;
using Repository.Common;
using Repository.Repositories;

namespace DAL.UnitOfWork;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;

    public SqlUnitOfWork(AppDbContext context, string connectionString)
    {
        _context = context;
        _connectionString = connectionString;
    }

    public ProductRepository _productRepository;    

    public IProductRepository ProductRepository => _productRepository?? new ProductRepository(_connectionString, _context);

    public async Task SaveChanges()
    {
        await  _context.SaveChangesAsync();
    }
}