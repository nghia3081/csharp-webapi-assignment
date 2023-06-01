using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly OrderClient OrderClient;
        public IEnumerable<BusinessObject.Order> Orders { get; set; }
        public IndexModel(OrderClient OrderClient)
        {
            this.OrderClient = OrderClient;
        }
        public async Task<IActionResult> OnGet()
        {
            Orders = await OrderClient.Get<IEnumerable<BusinessObject.Order>>(queryString: "include=OrderDetails");
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Order Order)
        {
            await OrderClient.Delete($"api/order/{Order.OrderId}");
            return await OnGet();
        }
    }
}
