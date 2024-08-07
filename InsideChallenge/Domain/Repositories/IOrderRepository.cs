using InsideChallenge.Domain.Entities;

namespace InsideChallenge.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAll();
    }
}
