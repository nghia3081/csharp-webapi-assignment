using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Application_Client.Pages.Member
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public BusinessObject.Member? Member { get; set; }
        private readonly MemberClient MemberClient;
        private readonly AppSetting appSetting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        public FormModel(MemberClient MemberClient, IOptions<AppSetting> appSetting, IHttpContextAccessor httpContextAccessor)
        {
            this.MemberClient = MemberClient;
            this.appSetting = appSetting.Value;
            _httpContextAccessor = httpContextAccessor;
            session = _httpContextAccessor.HttpContext.Session;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            bool isAdmin = (session.GetInt32(Constant.IsAdminSessionKey) ?? 0) == 1;
            BusinessObject.Member member = JsonConvert.DeserializeObject<BusinessObject.Member>(session.GetString(Constant.UserSessionKey));
            if (!isAdmin && (id is null || id.Value != member.MemberId))
            {
                return RedirectToPage("Index");
            }
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
