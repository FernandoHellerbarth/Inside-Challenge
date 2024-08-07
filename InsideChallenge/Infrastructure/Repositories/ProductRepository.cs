using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using InsideChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InsideChallenge.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InsideChallengeContext _context;

        public ProductRepository(InsideChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product?>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
