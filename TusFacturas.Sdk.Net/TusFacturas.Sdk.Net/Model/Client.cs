﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json.Serialization;
using Tusfacturas.Sdk.Net.Model.Enum;

namespace Tusfacturas.Sdk.Net.Model
{
    public class Client
    {
        [JsonProperty("documento_tipo")]
        [JsonPropertyName("documento_tipo")]
        public string DocumentoTipo { get; set; }

        [JsonProperty("documento_nro")]
        [JsonPropertyName("documento_nro")]
        public string DocumentoNro { get; set; }

        [JsonProperty("razon_social")]
        [JsonPropertyName("razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        
        [JsonProperty("domicilio")]
        [JsonPropertyName("domicilio")]
        public string Domicilio { get; set; }

        private string _provincia;
        [JsonProperty("provincia")]
        [JsonPropertyName("provincia")]
        public string Provincia
        {
            get => GetIntFromEnumName(_provincia.ToUpper().Replace(" ", string.Empty));
            set => _provincia = value;
        }

        [JsonProperty("envia_por_mail")]
        [JsonPropertyName("envia_por_mail")]
        public string EnviaPorMail { get; set; }

        [JsonProperty("condicion_pago")]
        [JsonPropertyName("condicion_pago")]
        public string CondicionPago { get; set; }

        [JsonProperty("condicion_pago_otra")]
        [JsonPropertyName("condicion_pago_otra")]
        public string CondicionPagoOtra { get; set; }

        [JsonProperty("condicion_iva")]
        [JsonPropertyName("condicion_iva")]
        public string CondicionIva { get; set; }

        [JsonProperty("reclama_deuda")]
        [JsonPropertyName("reclama_deuda")]
        public string ReclamaDeuda { get; set; }

        [JsonProperty("reclama_deuda_dias")]
        [JsonPropertyName("reclama_deuda_dias")]
        public int ReclamaDeudaDias { get; set; }

        [JsonProperty("reclama_deuda_repite_dias")]
        [JsonPropertyName("reclama_deuda_repite_dias")]
        public int ReclamaDeudaRepiteDias { get; set; }

        [JsonProperty("rg5329")]
        [JsonPropertyName("rg5329")]
        public string Rg5329 { get; set; }

        [JsonProperty("codigo")]
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        private string GetIntFromEnumName(string name)
        {
            try
            {
                return ((int)System.Enum.Parse(typeof(Provincias), name)).ToString();
            }
            catch (Exception)
            {
                return ((int)Provincias.Otro).ToString();
            }            
        }

        private string GetEnumNameFromInt(int value)
        {
            return System.Enum.GetName(typeof(Provincias), (Provincias)value);
        }
    }
}