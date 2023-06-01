using BusinessObject;
using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public class MemberClient : BaseClient<Member>
    {
        private const string memberUri = "api/member";
        public MemberClient(IOptions<AppSetting> options) : base(options, memberUri) { }
        public async Task<Member> Login(Member member)
        {
            return await base.Post(member, uri: $"{memberUri}/login");
        }
    }
}
