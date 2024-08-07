using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using InsideChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InsideChallenge.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly InsideChallengeContext _context;

        public OrderRepository(InsideChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Order> GetAll()
        {
            var orders = _context.Orders.Include(x => x.Items).ThenInclude(x => x.Product);
            return orders;
        }

        public async Task<List<Order?>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
