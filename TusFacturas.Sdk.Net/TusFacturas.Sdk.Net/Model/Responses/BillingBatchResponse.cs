using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Responses
{
    public class BillingBatchResponse
    {
        [JsonProperty("error")]
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonProperty("errores")]
        [JsonPropertyName("errores")]
        public List<string> Errores { get; set; }

        [JsonProperty("response")]
        [JsonPropertyName("response")]
        public List<BillingResponse> Response { get; set; }

    }
}
