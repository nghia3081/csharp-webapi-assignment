using BusinessObject;
using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public class ProductClient : BaseClient<Product>
    {
        private const string productUri = "api/product";
        public ProductClient(IOptions<AppSetting> options) : base(options, productUri) { }

    }
}
