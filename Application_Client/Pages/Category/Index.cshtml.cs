using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly CategoryClient categoryClient;
        public IEnumerable<BusinessObject.Category> Categories { get; set; }
        public IndexModel(CategoryClient categoryClient)
        {
            this.categoryClient = categoryClient;
        }
        public async Task<IActionResult> OnGet()
        {
            Categories = await categoryClient.Get<IEnumerable<BusinessObject.Category>>();
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Category category)
        {
            await categoryClient.Delete($"api/category/{category.CategoryId}");
            return await OnGet();
        }
    }
}
