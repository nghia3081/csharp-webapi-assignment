using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages
{
    public class SaleReportModel : PageModel
    {
        private readonly OrderDetailClient _client;
        public IEnumerable<BusinessObject.SaleReportModel> SaleReports { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime startDate { get; set; } = DateTime.Now.AddDays(-7);
        [BindProperty(SupportsGet = true)]
        public DateTime endDate { get; set; } = DateTime.Now;
        [BindProperty(SupportsGet = true)]
        public bool descendingOrder { get; set; } = true;
        public SaleReportModel(OrderDetailClient baseClient)
        {
            _client = baseClient;
        }
        public async Task OnGet()
        {
            SaleReports = new List<BusinessObject.SaleReportModel>();
        }
        public async Task OnPostList()
        {
            string queryString = $"startDate={startDate}&endDate={endDate}&descendingOrder={descendingOrder}";
            SaleReports = await _client.Get<IEnumerable<BusinessObject.SaleReportModel>>(uri: "api/order-detail/sale-report", queryString: queryString);
        }
    }
}
