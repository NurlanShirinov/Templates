using Common.Exceptions;
using DAL.Context;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.Infrastructure;

public class ProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(string connectionString, AppDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
    }

    public void Delete(int id)
    {
        var currentEntity = _context.Products.FirstOrDefault(p => p.Id == id);
        currentEntity.IsDeleted = true;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var sql = $@"SELECT * FROM Products WHERE IsDeleted = 0";
        using var conn = OpenConnection();
        return await conn.QueryAsync<Product>(sql, conn);
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        var sql = $@"SELECT * FROM Products WHERE IsDeleted = 0 AND Id = @id";
        using var conn = OpenConnection();
        var currentEntity =  await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id });
        if (currentEntity == null)
            throw new BadRequestException();
        return currentEntity;
    }

    public void Update(Product product)
    {
        _context.Update(product);
    }
}
