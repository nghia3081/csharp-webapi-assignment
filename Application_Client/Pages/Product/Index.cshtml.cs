using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages.Product
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? productName { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? unitPrice { get; set; }
        private readonly ProductClient ProductClient;
        public IEnumerable<BusinessObject.Product> Products { get; set; }
        public IndexModel(ProductClient ProductClient)
        {
            Products = new List<BusinessObject.Product>();
            this.ProductClient = ProductClient;
        }
        public async Task<IActionResult> OnGet()
        {
            string queryString = "include=Category";
            if (!string.IsNullOrEmpty(productName)) queryString += $"&productName={productName}";
            if (unitPrice.HasValue) queryString += $"&unitPrice={unitPrice}";
            string uri = "api/product/with-filter";
            Products = await ProductClient.Get<IEnumerable<BusinessObject.Product>>(uri: uri, queryString: queryString);
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Product Product)
        {
            await ProductClient.Delete($"api/product/{Product.ProductId}");
            return await OnGet();
        }
    }
}
