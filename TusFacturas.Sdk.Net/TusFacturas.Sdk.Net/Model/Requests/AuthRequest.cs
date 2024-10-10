using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Requests
{
    public class AuthRequest
    {
        [JsonProperty("usertoken")]
        [JsonPropertyName("usertoken")]
        public string UserToken { get; set; }
        [JsonProperty("apitoken")]
        [JsonPropertyName("apitoken")]
        public string ApiToken { get; set; }
        [JsonProperty("apikey")]
        [JsonPropertyName("apikey")]
        public string ApiKey { get; set; }
    }
}