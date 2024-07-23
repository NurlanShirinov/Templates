using DAL.Context;
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

    public IProductRepository ProductRepository => throw new NotImplementedException();

    public async Task SaveChanges()
    {
        await  _context.SaveChangesAsync();
    }
}