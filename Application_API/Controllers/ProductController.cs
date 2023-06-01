using BusinessObject;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    public class ProductController : BaseApiController<Product>
    {
        public ProductController(IProductRepository productRepository) : base(productRepository)
        {
        }
        [HttpGet("with-filter")]
        
        public async Task<IEnumerable<Product>> Get(string? include, string? productName, decimal? unitPrice)
        {
            return await (repository as IProductRepository).Get(include, productName, unitPrice);
        }
    }
}
