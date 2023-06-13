using BusinessObject;
using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public class OrderClient : BaseClient<Order>
    {
        private const string orderUri = "api/order";
        public OrderClient(IOptions<AppSetting> options) : base(options, orderUri) { }

    }
}
