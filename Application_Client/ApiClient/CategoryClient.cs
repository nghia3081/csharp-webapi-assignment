using BusinessObject;
using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public class CategoryClient : BaseClient<Category>
    {
        private const string categoryUri = "api/category";
        public CategoryClient(IOptions<AppSetting> options) : base(options, categoryUri) { }

    }
}
