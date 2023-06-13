using Microsoft.Extensions.Options;

namespace Application_Client.ApiClient
{
    public abstract class BaseClient<T>
        where T : class
    {
        protected readonly HttpClient client;
        private readonly AppSetting appSetting;
        private readonly string Uri;
        public BaseClient(IOptions<AppSetting> options, string uri)
        {
            appSetting = options.Value;
            client = new HttpClient()
            {
                BaseAddress = new Uri(appSetting.ApplicationApiBaseUrl)
            };
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            this.Uri = uri;
        }
        public virtual async Task<T?> Get(string? uri = null, string? queryString = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uri)) uri = this.Uri;
            if (!string.IsNullOrEmpty(queryString)) uri = $"{uri}?{queryString}";
            var response = await client.GetAsync(uri, cancellationToken);
            response.CustomEnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
        }
        public virtual async Task<U?> Get<U>(string? uri = null, string? queryString = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uri)) uri = this.Uri;
            if (!string.IsNullOrEmpty(queryString)) uri = $"{uri}?{queryString}";
            var response = await client.GetAsync(uri, cancellationToken);
            response.CustomEnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<U>(cancellationToken: cancellationToken);
        }
        public virtual async Task<T?> Post(T data, string? uri = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uri)) uri = this.Uri;
            var response = await client.PostAsJsonAsync(uri, data, cancellationToken);
            response.CustomEnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
        }
        public virtual async Task<T?> Put(T data, string? uri = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uri)) uri = this.Uri;
            var response = await client.PutAsJsonAsync(uri, data, cancellationToken);
            response.CustomEnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
        }
        public virtual async Task Delete(string? uri = null, string? queryString = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uri)) uri = this.Uri;
            if (!string.IsNullOrEmpty(queryString)) uri = $"{uri}?{queryString}";
            var response = await client.DeleteAsync(uri, cancellationToken);
            response.CustomEnsureSuccessStatusCode();
        }
    }
}
