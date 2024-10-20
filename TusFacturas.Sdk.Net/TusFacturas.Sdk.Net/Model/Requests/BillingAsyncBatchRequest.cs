using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Requests
{
    public class BillingAsyncBatchRequest : AuthRequest
    {
        [JsonProperty("requests")]
        [JsonPropertyName("requests")]
        public Receipt[] Receipts { get; set; }
    }
}
