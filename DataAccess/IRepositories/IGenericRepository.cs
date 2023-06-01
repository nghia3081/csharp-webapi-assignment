namespace DataAccess.IRepositories
{
    public interface IGenericRepository<U>
        where U : class
    {
        Task<U> Create(U businessObject, CancellationToken cancellationToken = default);
        Task<U> Update(U businessObject, CancellationToken cancellationToken = default);
        Task Delete(CancellationToken cancellationToken = default, params object[] entityKeys);
        Task<U> Find(CancellationToken cancellationToken = default, params object[] entityKeys);
        Task<IEnumerable<U>> GetAll(string? include = null, CancellationToken cancellationToken = default);
    }
}
