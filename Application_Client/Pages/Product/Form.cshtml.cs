using Application_Client.ApiClient;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application_Client.Pages.Product
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public BusinessObject.Product? Product { get; set; }
        public SelectList? Categories { get; set; }
        private readonly ProductClient ProductClient;
        public FormModel(ProductClient ProductClient)
        {
            this.ProductClient = ProductClient;
        }
        private async Task GetCategoryOptions()
        {
            string uri = "api/category";
            var categories = await ProductClient.Get<IEnumerable<BusinessObject.Category>>(uri);
            Categories = new SelectList(categories, "CategoryId", "CategoryName", categories?.First());
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            await GetCategoryOptions();
            if (id != null && id != 0) Product = await ProductClient.Get($"api/product/{id}");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Product is null || !ModelState.IsValid) return await OnGet(Product?.ProductId);
            if (Product.ProductId == 0)
            {
                await ProductClient.Post(Product);
            }
            else
            {
                await ProductClient.Put(Product);
            }

            return RedirectToPage("Index");
        }
    }
}
