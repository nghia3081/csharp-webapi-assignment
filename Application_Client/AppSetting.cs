namespace Application_Client
{
    public class AppSetting
    {
        public string ApplicationApiBaseUrl { get; set; } = null!;
        public Account AdminAccount { get; set; } = null!;
    }
    public class Account
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class Constant
    {
        public const string UserSessionKey = "User";
        public const string IsAdminSessionKey = "IsAdmin";
    }
}
