using AutoMapper;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class ProductRepository : GenericRepository<Models.Product, BusinessObject.Product>, IProductRepository
    {
        public ProductRepository(EStoreContext eStoreContext, IMapper mapper) : base(eStoreContext, mapper) { }

        public async Task<IEnumerable<BusinessObject.Product>> Get(string? include, string? productName, decimal? unitPrice)
        {
            return await Task.Run<IEnumerable<BusinessObject.Product>>(() =>
               {
                   IQueryable<Product> data = Set;
                   if (productName != null)
                       data = data.Where(product => product.ProductName.Contains(productName));
                   if (unitPrice != null)
                       data = data.Where(product => product.UnitPrice.ToString().Contains(unitPrice.ToString()));
                   if (include != null) data = data.Include(include);
                   return mapper.Map<IEnumerable<Product>, IEnumerable<BusinessObject.Product>>(data.AsEnumerable());
               });
        }
    }
}
