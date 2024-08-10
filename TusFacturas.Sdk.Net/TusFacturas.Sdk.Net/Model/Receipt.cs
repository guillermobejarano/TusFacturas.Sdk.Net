using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tusfacturas.Sdk.Net.Model
{
    public class Receipt
    {
        [JsonProperty("fecha")]
        [JsonPropertyName("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("tipo")]
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("moneda")]
        [JsonPropertyName("moneda")]
        public string Moneda { get; set; }

        [JsonProperty("idioma")]
        [JsonPropertyName("idioma")]
        public string Idioma { get; set; }

        [JsonProperty("cotizacion")]
        [JsonPropertyName("cotizacion")]
        public string Cotizacion { get; set; }

        [JsonProperty("operacion")]
        [JsonPropertyName("operacion")]
        public string Operacion { get; set; }

        [JsonProperty("punto_venta")]
        [JsonPropertyName("punto_venta")]
        public string PuntoVenta { get; set; }

        [JsonProperty("numero")]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonProperty("periodo_facturado_desde")]
        [JsonPropertyName("periodo_facturado_desde")]
        public string PeriodoFacturadoDesde { get; set; }

        [JsonProperty("periodo_facturado_hasta")]
        [JsonPropertyName("periodo_facturado_hasta")]
        public string PeriodoFacturadoHasta { get; set; }

        [JsonProperty("vencimiento")]
        [JsonPropertyName("vencimiento")]
        public string Vencimiento { get; set; }

        [JsonProperty("rubro")]
        [JsonPropertyName("rubro")]
        public string Rubro { get; set; }

        [JsonProperty("external_reference")]
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }

        [JsonProperty("tags")]
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("rubro_grupo_contable")]
        [JsonPropertyName("rubro_grupo_contable")]
        public string RubroGrupoContable { get; set; }

        [JsonProperty("abono")]
        [JsonPropertyName("abono")]
        public string Abono { get; set; }

        [JsonProperty("abono_frecuencia")]
        [JsonPropertyName("abono_frecuencia")]
        public string AbonoFrecuencia { get; set; }

        [JsonProperty("abono_hasta")]
        [JsonPropertyName("abono_hasta")]
        public string AbonoHasta { get; set; }

        [JsonProperty("abono_actualiza_precios")]
        [JsonPropertyName("abono_actualiza_precios")]
        public string AbonoActualizaPrecios { get; set; }

        [JsonProperty("detalle")]
        [JsonPropertyName("detalle")]
        public List<Detalle> Detalle { get; set; }

        [JsonProperty("rg_especiales")]
        [JsonPropertyName("rg_especiales")]
        public RgEspeciales RgEspeciales { get; set; }

        [JsonProperty("comprobantes_asociados")]
        [JsonPropertyName("comprobantes_asociados")]
        public List<ComprobantesAsociado> ComprobantesAsociados { get; set; }

        [JsonProperty("comprobantes_asociados_periodo")]
        [JsonPropertyName("comprobantes_asociados_periodo")]
        public ComprobantesAsociadosPeriodo ComprobantesAsociadosPeriodo { get; set; }

        [JsonProperty("pagos")]
        [JsonPropertyName("pagos")]
        public Pagos Pagos { get; set; }

        [JsonProperty("tributos")]
        [JsonPropertyName("tributos")]
        public List<Tributo> Tributos { get; set; }

        [JsonProperty("exentos")]
        [JsonPropertyName("exentos")]
        public string Exentos { get; set; }

        [JsonProperty("impuestos_internos")]
        [JsonPropertyName("impuestos_internos")]
        public string ImpuestosInternos { get; set; }

        [JsonProperty("impuestos_internos_base")]
        [JsonPropertyName("impuestos_internos_base")]
        public string ImpuestosInternosBase { get; set; }

        [JsonProperty("impuestos_internos_alicuota")]
        [JsonPropertyName("impuestos_internos_alicuota")]
        public string ImpuestosInternosAlicuota { get; set; }

        [JsonProperty("bonificacion")]
        [JsonPropertyName("bonificacion")]
        public string Bonificacion { get; set; }

        [JsonProperty("leyenda_gral")]
        [JsonPropertyName("leyenda_gral")]
        public string LeyendaGral { get; set; }

        [JsonProperty("comentario")]
        [JsonPropertyName("comentario")]
        public string Comentario { get; set; }

        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public string Total { get; set; }
    }

    public class ComprobantesAsociado
    {
        [JsonProperty("tipo_comprobante")]
        [JsonPropertyName("tipo_comprobante")]
        public string TipoComprobante { get; set; }

        [JsonProperty("punto_venta")]
        [JsonPropertyName("punto_venta")]
        public string PuntoVenta { get; set; }

        [JsonProperty("numero")]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonProperty("comprobante_fecha")]
        [JsonPropertyName("comprobante_fecha")]
        public string ComprobanteFecha { get; set; }

        [JsonProperty("cuit")]
        [JsonPropertyName("cuit")]
        public long Cuit { get; set; }
    }

    public class ComprobantesAsociadosPeriodo
    {
        [JsonProperty("fecha_desde")]
        [JsonPropertyName("fecha_desde")]
        public string FechaDesde { get; set; }

        [JsonProperty("fecha_hasta")]
        [JsonPropertyName("fecha_hasta")]
        public string FechaHasta { get; set; }
    }

    public class Dato
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("valor")]
        [JsonPropertyName("valor")]
        public string Valor { get; set; }
    }

    public class Detalle
    {
        [JsonProperty("cantidad")]
        [JsonPropertyName("cantidad")]
        public string Cantidad { get; set; }

        [JsonProperty("afecta_stock")]
        [JsonPropertyName("afecta_stock")]
        public string AfectaStock { get; set; }

        [JsonProperty("bonificacion_porcentaje")]
        [JsonPropertyName("bonificacion_porcentaje")]
        public string BonificacionPorcentaje { get; set; }

        [JsonProperty("producto")]
        [JsonPropertyName("producto")]
        public Producto Producto { get; set; }

        [JsonProperty("leyenda")]
        [JsonPropertyName("leyenda")]
        public string Leyenda { get; set; }
    }

    public class FormasPago
    {
        [JsonProperty("descripcion")]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("importe")]
        [JsonPropertyName("importe")]
        public double Importe { get; set; }
    }

    public class Pagos
    {
        [JsonProperty("formas_pago")]
        [JsonPropertyName("formas_pago")]
        public List<FormasPago> FormasPago { get; set; }

        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public double Total { get; set; }
    }

    public class Producto
    {
        [JsonProperty("descripcion")]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("unidad_bulto")]
        [JsonPropertyName("unidad_bulto")]
        public string UnidadBulto { get; set; }

        [JsonProperty("lista_precios")]
        [JsonPropertyName("lista_precios")]
        public string ListaPrecios { get; set; }

        [JsonProperty("codigo")]
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("precio_unitario_sin_iva")]
        [JsonPropertyName("precio_unitario_sin_iva")]
        public string PrecioUnitarioSinIva { get; set; }

        [JsonProperty("alicuota")]
        [JsonPropertyName("alicuota")]
        public string Alicuota { get; set; }

        [JsonProperty("impuestos_internos_alicuota")]
        [JsonPropertyName("impuestos_internos_alicuota")]
        public int ImpuestosInternosAlicuota { get; set; }

        [JsonProperty("unidad_medida")]
        [JsonPropertyName("unidad_medida")]
        public string UnidadMedida { get; set; }

        [JsonProperty("actualiza_precio")]
        [JsonPropertyName("actualiza_precio")]
        public string ActualizaPrecio { get; set; }

        [JsonProperty("rg5329")]
        [JsonPropertyName("rg5329")]
        public string Rg5329 { get; set; }
    }

    public class RgEspeciales
    {
        [JsonProperty("regimen")]
        [JsonPropertyName("regimen")]
        public string Regimen { get; set; }

        [JsonProperty("datos")]
        [JsonPropertyName("datos")]
        public List<Dato> Datos { get; set; }
    }

    public class Tributo
    {
        [JsonProperty("tipo")]
        [JsonPropertyName("tipo")]
        public int Tipo { get; set; }

        [JsonProperty("regimen")]
        [JsonPropertyName("regimen")]
        public int Regimen { get; set; }

        [JsonProperty("base_imponible")]
        [JsonPropertyName("base_imponible")]
        public int BaseImponible { get; set; }

        [JsonProperty("alicuota")]
        [JsonPropertyName("alicuota")]
        public int Alicuota { get; set; }

        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
