using BusinessObject;
using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public class OrderDetailClient : BaseClient<OrderDetail>
    {
        private const string orderDetailUri = "api/order-detail";
        public OrderDetailClient(IOptions<AppSetting> options) : base(options, orderDetailUri) { }

    }
}
