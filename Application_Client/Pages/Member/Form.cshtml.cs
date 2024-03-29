using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace Application_Client.Pages.Member
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public BusinessObject.Member? Member { get; set; }
        private readonly MemberClient MemberClient;
        private readonly AppSetting appSetting;
        public FormModel(MemberClient MemberClient, IOptions<AppSetting> appSetting)
        {
            this.MemberClient = MemberClient;
            this.appSetting = appSetting.Value;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id != null)
            {
                Member = await MemberClient.Get($"api/member/{id}");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Member != null) ModelState.Remove("Member.Password");
            if (Member is null || !ModelState.IsValid) return Page();
            if (Member.Email.Equals(appSetting.AdminAccount.Email))
            {
                ModelState.AddModelError("Member.Email", "Email is existed, please enter other email");
                return Page();
            }
            try
            {
                if (Member.MemberId == 0)
                {
                    await MemberClient.Post(Member);
                }
                else
                {

                    await MemberClient.Put(Member);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("ERR01"))
                    ModelState.AddModelError("Member.Email", ex.Message);
                else ModelState.AddModelError("memberError", ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
