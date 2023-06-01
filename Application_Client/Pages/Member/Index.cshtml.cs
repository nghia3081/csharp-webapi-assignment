using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly MemberClient MemberClient;
        public IEnumerable<BusinessObject.Member> Members { get; set; }
        public IndexModel(MemberClient MemberClient)
        {
            this.MemberClient = MemberClient;
        }
        public async Task<IActionResult> OnGet()
        {
            Members = await MemberClient.Get<IEnumerable<BusinessObject.Member>>();
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Member Member)
        {
            await MemberClient.Delete($"api/member/{Member.MemberId}");
            return await OnGet();
        }
    }
}
