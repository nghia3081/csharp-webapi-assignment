using Application_Client.ApiClient;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Application_Client.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppSetting appSetting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        private readonly MemberClient memberClient;
        [BindProperty]
        public BusinessObject.Member? Member { get; set; }
        public string? Exception { get; set; }
        public LoginModel(IOptions<AppSetting> options
            , IHttpContextAccessor accessor
            , MemberClient memberClient)
        {
            _httpContextAccessor = accessor;
            appSetting = options.Value;
            this.session = _httpContextAccessor.HttpContext.Session;
            this.memberClient = memberClient;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Member == null) throw new ArgumentNullException(nameof(Member));
            int isAdmin = Member.Email == appSetting.AdminAccount.Email && Member.Password == appSetting.AdminAccount.Password ? 1 : 0;
            try
            {
                BusinessObject.Member member = isAdmin == 1 ? Member : await memberClient.Login(Member);
                session.SetString(Constant.UserSessionKey, JsonSerializer.Serialize(member));
                session.SetInt32(Constant.IsAdminSessionKey, isAdmin);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("loginException", ex.Message);
                return Page();
            }

        }
    }
}
