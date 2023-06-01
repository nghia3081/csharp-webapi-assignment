using AutoMapper;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class MemberRepository : GenericRepository<Models.Member, BusinessObject.Member>, IMemberRepository
    {
        public MemberRepository(EStoreContext eStoreContext, IMapper mapper) : base(eStoreContext, mapper) { }

        public async Task<BusinessObject.Member> Login(BusinessObject.Member member, CancellationToken cancellationToken = default)
        {
            if (member == null)
                throw new Exception("Please enter member");
            if (!Set.Any(mem => mem.Email == member.Email && mem.Password == member.Password))
                throw new Exception("Invalid email or password");
            return mapper.Map<Member, BusinessObject.Member>(await Set.FirstAsync(mem => mem.Email == member.Email && mem.Password == member.Password, cancellationToken));
        }
        public override Task<BusinessObject.Member> Update(BusinessObject.Member businessObject, CancellationToken cancellationToken = default)
        {
            if (Set.Any(mem => mem.MemberId != businessObject.MemberId && businessObject.Email == mem.Email))
                throw new Exception("ERR01: Email is existed");
            return base.Update(businessObject, cancellationToken);
        }
        public override Task<BusinessObject.Member> Create(BusinessObject.Member businessObject, CancellationToken cancellationToken = default)
        {
            if (Set.Any(mem => mem.MemberId != businessObject.MemberId && businessObject.Email == mem.Email))
                throw new Exception("ERR01: Email is existed");
            return base.Create(businessObject, cancellationToken);
        }
    }
}
