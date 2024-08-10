using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Requests
{
    internal class BillingAsyncBatchRequest : AuthRequest
    {
        [JsonProperty("requests")]
        [JsonPropertyName("requests")]
        public Receipt[] Receipts { get; set; }
    }
}
