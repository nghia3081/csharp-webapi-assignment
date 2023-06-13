using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Application_Client.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly OrderClient OrderClient;
        public IEnumerable<BusinessObject.Order> Orders { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        public IndexModel(OrderClient OrderClient, IHttpContextAccessor accessor)
        {
            this.OrderClient = OrderClient;
            _httpContextAccessor = accessor;
            this.session = _httpContextAccessor.HttpContext.Session;
        }
        public async Task<IActionResult> OnGet()
        {
            bool isAdmin = (session.GetInt32(Constant.IsAdminSessionKey) ?? 0) == 1;
            if (isAdmin)
            {
                Orders = await OrderClient.Get<IEnumerable<BusinessObject.Order>>(uri: "api/order/get-all");

            }
            else
            {
                BusinessObject.Member member = JsonConvert.DeserializeObject<BusinessObject.Member>(session.GetString(Constant.UserSessionKey));
                Orders = await OrderClient.Get<IEnumerable<BusinessObject.Order>>(uri: $"api/order/get-all?memberId={member.MemberId}");

            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Order Order)
        {
            await OrderClient.Delete($"api/order/{Order.OrderId}");
            return await OnGet();
        }
    }
}
