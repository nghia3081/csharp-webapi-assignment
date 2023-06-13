using Newtonsoft.Json.Linq;

namespace Application_Client.ApiClient
{
    public static class HttpClientExtension
    {
        public static void CustomEnsureSuccessStatusCode(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            var exception = response.Content.ReadAsStringAsync().Result;
            try
            {
                JObject keyValuePairs = JObject.Parse(exception);
                exception = keyValuePairs["message"]?.ToString();
                throw new Exception(keyValuePairs["message"]?.ToString());
            }
            catch (Exception)
            {
                throw new Exception(exception);
            }

        }
    }
}
