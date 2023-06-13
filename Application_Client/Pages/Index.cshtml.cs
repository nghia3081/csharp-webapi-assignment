using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession session;
        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _httpContextAccessor = accessor;
            this.session = _httpContextAccessor.HttpContext.Session;
        }

        public void OnGet()
        {

        }
        public void OnGetLogout()
        {
            session.Remove(Constant.UserSessionKey);
            session.Remove(Constant.IsAdminSessionKey);
        }
    }
}