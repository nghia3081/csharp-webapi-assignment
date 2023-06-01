using BusinessObject;
using DataAccess.IRepositories;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    public class OrderController : BaseApiController<Order>
    {
        public OrderController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }
    }
}
