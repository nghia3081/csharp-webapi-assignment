using AutoMapper;
using BusinessObject;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class OrderRepository : GenericRepository<Models.Order, BusinessObject.Order>, IOrderRepository
    {
        public OrderRepository(EStoreContext eStoreContext, IMapper mapper) : base(eStoreContext, mapper) { }

        new public async Task<BusinessObject.Order> Create(BusinessObject.Order order, CancellationToken cancellationToken = default)
        {
            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                var product = context.Products.Find(order.OrderDetails.ElementAt(i).ProductId);
                order.OrderDetails.ElementAt(i).UnitPrice = product.UnitPrice;
            }
            return await base.Create(order, cancellationToken);
        }

        public async Task<IEnumerable<BusinessObject.Order>> GetAll(int? memberId, CancellationToken cancellationToken = default)
        {
            IQueryable<Models.Order> data = this.Set;
            if (memberId != null) data = data.Where(od => od.MemberId == memberId);
            data = data.Include(od => od.Member).Include(od => od.OrderDetails)
             .ThenInclude(odd => odd.Product);

            return mapper.Map<IEnumerable<Models.Order>, IEnumerable<BusinessObject.Order>>(await data.ToListAsync(cancellationToken));
        }
    }
}
