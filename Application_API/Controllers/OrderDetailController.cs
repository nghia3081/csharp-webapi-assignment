using BusinessObject;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    [Route("/api/order-detail")]
    public class OrderDetailController : BaseApiController<OrderDetail>
    {
        public OrderDetailController(IOrderDetailRepository orderDetailRepository) : base(orderDetailRepository)
        {

        }
        [HttpGet("sale-report")]
        public IEnumerable<SaleReportModel> GetSaleReport([BindRequired] DateTime startDate, [BindRequired] DateTime endDate,[BindRequired] bool descendingOrder = true)
        {
            return (repository as IOrderDetailRepository).GetSaleReports(startDate, endDate, descendingOrder: descendingOrder);
        }
    }
}
