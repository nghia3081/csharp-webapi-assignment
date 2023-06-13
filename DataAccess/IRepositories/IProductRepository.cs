using BusinessObject;

namespace DataAccess.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> Get(string? include, string? productName, decimal? unitPrice);
    }
}
