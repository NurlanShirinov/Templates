using DAL.Context;
using Repository.Common;

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

    public async Task SaveChanges()
    {
        await  _context.SaveChangesAsync();
    }
}