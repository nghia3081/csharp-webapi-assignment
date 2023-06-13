using BusinessObject;

namespace DataAccess.IRepositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member> Login(Member member, CancellationToken cancellationToken = default);
    }
}
