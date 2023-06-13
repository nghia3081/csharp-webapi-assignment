using BusinessObject;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    public class MemberController : BaseApiController<Member>
    {
        public MemberController(IMemberRepository memberRepository) : base(memberRepository)
        {
        }
        [HttpPost("login")]
        public async Task<Member> Login(Member member)
        {
            return await (repository as IMemberRepository).Login(member);
        }
    }
}
