using Common.Exceptions;
using DAL.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.Infrastructure;

public class ProductCategory : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductCategory(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
    }

    public async Task Delete(int id)
    {
       var currentEntity =  await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (currentEntity != null)
            currentEntity.IsDeleted = true;
        else
            throw new BadRequestException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }
}
