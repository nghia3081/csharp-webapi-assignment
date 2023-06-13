using BusinessObject;

namespace DataAccess.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetAll(int? memberId, CancellationToken cancellationToken = default);
        new Task<Order> Create(Order order, CancellationToken cancellationToken = default);
    }
}
