using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages.Category
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public BusinessObject.Category? Category { get; set; }
        private readonly CategoryClient categoryClient;
        public FormModel(CategoryClient categoryClient)
        {
            this.categoryClient = categoryClient;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id != null) Category = await categoryClient.Get(uri: $"api/category/{id}");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category is null || !ModelState.IsValid) return Page();
            if (Category.CategoryId == 0)
            {
                await categoryClient.Post(Category);
            }
            else
            {
                await categoryClient.Put(Category);
            }

            return RedirectToPage("Index");
        }
    }
}
