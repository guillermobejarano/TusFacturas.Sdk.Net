using Newtonsoft.Json;
using Tusfacturas.Sdk.Net.Clients;

namespace Tusfacturas.Sdk.Net.Services
{
    internal class Service
    {
        protected string endpoint;
        protected RestClient restClient;

        protected const string CONTENT_TYPE_APP_JSON = "application/json";
        protected const string METHOD_POST = "POST";
        protected const string METHOD_GET = "GET";
        protected const int STATUS_OK = 200;
        protected const int STATUS_CREATED = 201;
        protected const int STATUS_NOCONTENT = 204;

        public Service(string endpoint)
        {
            this.endpoint = endpoint;
        }

        public string ToJson<T>(T request)
        {
            return JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.None);
        }
    }
}
