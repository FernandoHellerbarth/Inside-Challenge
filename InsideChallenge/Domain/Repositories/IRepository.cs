﻿using InsideChallenge.Domain.Entities;

namespace InsideChallenge.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
