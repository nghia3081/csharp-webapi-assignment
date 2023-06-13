using BusinessObject;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    public class OrderController : BaseApiController<Order>
    {
        public OrderController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }
        [HttpGet("get-all")]
        public async Task<IEnumerable<Order>> GetOrders(int? memberId)
        {
            return await (repository as IOrderRepository).GetAll(memberId);
        }
    }
}
