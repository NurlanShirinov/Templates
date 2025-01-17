﻿using Domain.Entities;

namespace Repository.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    void Delete(int id);
    void Update(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync(); 
}