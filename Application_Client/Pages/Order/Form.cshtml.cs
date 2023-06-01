using Application_Client.ApiClient;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Application_Client.Pages.Order
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public BusinessObject.Order Order { get; set; }
        public SelectList ProductSelection { get; set; }
        private readonly ProductClient productClient;
        private readonly MemberClient memberClient;
        private readonly OrderClient orderClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        public SelectList MemberSelection { get; set; }
        public FormModel(ProductClient productClient, OrderClient orderClient, IHttpContextAccessor accessor, MemberClient memberClient)
        {
            ProductSelection = new(new List<BusinessObject.Product>());
            this.productClient = productClient;
            this.orderClient = orderClient;
            _httpContextAccessor = accessor;
            this.memberClient = memberClient;
            this.session = _httpContextAccessor.HttpContext.Session;
            this.MemberSelection = new(new List<BusinessObject.Member>());
        }
        public async Task OnGet()
        {
            var productList = await productClient.Get<IEnumerable<BusinessObject.Product>>();
            var memberList = await memberClient.Get<IEnumerable<BusinessObject.Member>>();
            ProductSelection = new(productList, "ProductId", "ProductName");
            MemberSelection = new(memberList, "MemberId", "Email");
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            Order.OrderDate = DateTime.Now;
            await orderClient.Post(Order);
            return RedirectToPage("Index");
        }
    }
}
