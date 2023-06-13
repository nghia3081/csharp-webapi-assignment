using Application_Client.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Application_Client.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly MemberClient MemberClient;
        public IEnumerable<BusinessObject.Member> Members { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        public IndexModel(MemberClient MemberClient, IHttpContextAccessor httpContextAccessor)
        {
            this.MemberClient = MemberClient;
            _httpContextAccessor = httpContextAccessor;
            session = _httpContextAccessor.HttpContext.Session;
        }
        public async Task<IActionResult> OnGet()
        {
            bool isAdmin = (session.GetInt32(Constant.IsAdminSessionKey) ?? 0) == 1;
            if (isAdmin)
            {
                Members = await MemberClient.Get<IEnumerable<BusinessObject.Member>>();
            }
            else
            {
                BusinessObject.Member member = JsonConvert.DeserializeObject<BusinessObject.Member>(session.GetString(Constant.UserSessionKey));
                Members = new List<BusinessObject.Member>() { member };
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDelete(BusinessObject.Member Member)
        {
            await MemberClient.Delete($"api/member/{Member.MemberId}");
            return await OnGet();
        }
    }
}
