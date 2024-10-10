using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model.Responses
{
    public class BillingResponse
    {
        [JsonProperty("error")]
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonProperty("errores")]
        [JsonPropertyName("errores")]
        public List<string> Errores { get; set; }

        [JsonProperty("rta")]
        [JsonPropertyName("rta")]
        public string Rta { get; set; }

        [JsonProperty("cae")]
        [JsonPropertyName("cae")]
        public string Cae { get; set; }

        [JsonProperty("requiere_fec")]
        [JsonPropertyName("requiere_fec")]
        public string RequiereFec { get; set; }

        [JsonProperty("vencimiento_cae")]
        [JsonPropertyName("vencimiento_cae")]
        public string VencimientoCae { get; set; }

        [JsonProperty("vencimiento_pago")]
        [JsonPropertyName("vencimiento_pago")]
        public string VencimientoPago { get; set; }

        [JsonProperty("comprobante_pdf_url")]
        [JsonPropertyName("comprobante_pdf_url")]
        public string ComprobantePdfUrl { get; set; }

        [JsonProperty("comprobante_ticket_url")]
        [JsonPropertyName("comprobante_ticket_url")]
        public string ComprobanteTicketUrl { get; set; }

        [JsonProperty("afip_codigo_barras")]
        [JsonPropertyName("afip_codigo_barras")]
        public string AfipCodigoBarras { get; set; }

        [JsonProperty("envio_x_mail")]
        [JsonPropertyName("envio_x_mail")]
        public string EnvioXMail { get; set; }

        [JsonProperty("external_reference")]
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }

        [JsonProperty("comprobante_nro")]
        [JsonPropertyName("comprobante_nro")]
        public string ComprobanteNro { get; set; }

        [JsonProperty("comprobante_tipo")]
        [JsonPropertyName("comprobante_tipo")]
        public string ComprobanteTipo { get; set; }

        [JsonProperty("micrositios")]
        [JsonPropertyName("micrositios")]
        public MicrositiosResponse Micrositios { get; set; }

        [JsonProperty("envio_x_mail_direcciones")]
        [JsonPropertyName("envio_x_mail_direcciones")]
        public string EnvioXMailDirecciones { get; set; }
    }

    public class MicrositiosResponse
    {
        [JsonProperty("cliente")]
        [JsonPropertyName("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("descarga")]
        [JsonPropertyName("descarga")]
        public string Descarga { get; set; }
    }

}
