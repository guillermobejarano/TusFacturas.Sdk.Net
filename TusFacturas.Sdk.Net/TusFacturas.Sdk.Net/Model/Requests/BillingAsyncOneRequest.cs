using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Requests
{
    internal class BillingAsyncOneRequest : AuthRequest
    {
        [JsonProperty("comprobante")]
        [JsonPropertyName("comprobante")]
        public Receipt Receipt { get; set; }
        [JsonProperty("cliente")]
        [JsonPropertyName("cliente")]
        public Client Client { get; set; }
    }
}
