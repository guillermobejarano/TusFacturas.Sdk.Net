using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tusfacturas.Sdk.Net.Clients;
using Tusfacturas.Sdk.Net.Exceptions;
using Tusfacturas.Sdk.Net.Model.ErrorResponses;
using Tusfacturas.Sdk.Net.Model.Requests;
using Tusfacturas.Sdk.Net.Model.Responses;

namespace Tusfacturas.Sdk.Net.Services
{
    public interface IBillingService
    {
        BillingBatchResponse BillignInstantBatch(BillingAsyncBatchRequest billReq);
        Task<BillingBatchResponse> BillingAsyncBatch(BillingAsyncBatchRequest billReq);
        BillingResponse BillignInstantOne(BillingAsyncOneRequest billReq);
        Task<BillingResponse> BillingAsyncOne(BillingAsyncOneRequest billReq);
    }

    public class BillingService : Service, IBillingService
    {
        private const string CONTROLLER_NAME = "facturacion";
        private readonly string _userToken;
        private readonly string _apiKey;
        private readonly string _apiToken;
        //private readonly BillingAsyncOneRequest _billingAsyncOneRequest;


        public BillingService(string endpoint, string apiKey, string apiToken, string userToken) : base(endpoint)
        {
            _userToken = userToken;
            _apiKey = apiKey;
            _apiToken = apiToken;

            var headers = new Dictionary<string, string>();
            //headers.Add("apikey", this.privateApiKey);
            //headers.Add("Cache-Control", "no-cache");

            this.restClient = new RestClient(this.endpoint, headers, CONTENT_TYPE_APP_JSON);
        }

        public BillingBatchResponse BillignInstantBatch(BillingAsyncBatchRequest billReq)
        {
            var response = new BillingBatchResponse();

            billReq.ApiKey = _apiKey;
            billReq.ApiToken = _apiToken;
            billReq.UserToken = _userToken;

            foreach (var item in billReq.Receipts)
            {
                item.ApiKey = _apiKey;
                item.ApiToken = _apiToken;
                item.UserToken = _userToken;
            }


            #region Validaciones
            //Comprobamos que la lista contenga elementos
            if (billReq.Receipts == null || !billReq.Receipts.Any()) throw new ArgumentException("La lista de comprobantes no puede estar vacía.");

            //comprabamos que no sean mas de 20 request por lote
            if (billReq.Receipts.Length > 20) throw new ArgumentOutOfRangeException("Receipts","El número maximo de comprobantes permitidos es 20.");

            //comprobar que sean del mismo tipo
            var tipoReferencia = billReq.Receipts.First().Receipt.Tipo;

            if(!billReq.Receipts.All(x => x.Receipt.Tipo == tipoReferencia)) throw new InvalidOperationException("Todos los comprobantes deben ser del mismo tipo. Ej: FACTURA A.");

            //Comprobamos que sean de tipo A o B o C y no sean de tipo E o Factura de credito(FEC)
            var tiposRequeridos = new List<string>() { "FACTURA A", "FACTURA B", "FACTURA C" };

            if(!billReq.Receipts.All(x => tiposRequeridos.Contains(x.Receipt.Tipo))) throw new InvalidOperationException("Debe haber al menos un tipo de comprobante requerido: FACTURA A, FACTURA B o FACTURA C.");

            //Ordenamos por numero ascendente

            billReq.Receipts = billReq.Receipts
                                        .OrderBy(x => int.Parse(x.Receipt.Numero))
                                        .Select(x => {
                                            x.Receipt.Numero = int.Parse(x.Receipt.Numero).ToString();
                                            return x;
                                        })
                                        .ToArray();

            #endregion

            var result = this.restClient.Post($"{CONTROLLER_NAME}/lotes", base.ToJson<BillingAsyncBatchRequest>(billReq));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<BillingBatchResponse>(result.Response);
            }

            if (result.StatusCode != STATUS_CREATED)
            {
                throw new Exception(result.StatusCode.ToString());
            }

            return response;
        }

        public BillingResponse BillignInstantOne(BillingAsyncOneRequest billReq)
        {
            var response = new BillingResponse();

            billReq.ApiKey = _apiKey;
            billReq.ApiToken = _apiToken;
            billReq.UserToken = _userToken;

            var result = this.restClient.Post($"{CONTROLLER_NAME}/nuevo", base.ToJson<BillingAsyncOneRequest>(billReq));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<BillingResponse>(result.Response);
            }

            if (response.Error?.Contains("S") == true)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(result.Response);

                throw new ResponseException(errorResponse);
            }

            return response;
        }

        public async Task<BillingBatchResponse> BillingAsyncBatch(BillingAsyncBatchRequest billReq)
        {
            var response = new BillingBatchResponse();

            billReq.ApiKey = _apiKey;
            billReq.ApiToken = _apiToken;
            billReq.UserToken = _userToken;

            foreach (var item in billReq.Receipts)
            {
                item.ApiKey = _apiKey;
                item.ApiToken = _apiToken;
                item.UserToken = _userToken;
            }

            #region Validaciones
            //Comprobamos que la lista contenga elementos
            if (billReq.Receipts == null || !billReq.Receipts.Any()) throw new ArgumentException("La lista de comprobantes no puede estar vacía.");

            //comprabamos que no sean mas de 100 request por lote
            if (billReq.Receipts.Length > 100) throw new ArgumentOutOfRangeException("Receipts", "El número maximo de comprobantes permitidos es 100.");

            //Solamente puede enviarse facturas con fecha de hoy en adelante
            if (billReq.Receipts.Select(x => x.Receipt).Any(x => DateTime.Parse(x.Fecha) < DateTime.Now.Date)) throw new InvalidOperationException("Las fechas de las facturas deben ser posterior a hoy.");

            //El campo numero debe ser (0)
            if(billReq.Receipts.Select(x => x.Receipt).Any(x => x.Numero != "0")) throw new ArgumentException("El campo número debe de ser 0.");

            //Debes enviar un "external_reference" de manera obligatoria y debería ser único.
            var externalReferences = billReq.Receipts.Select(x => x.Receipt.ExternalReference).Where(reference => !string.IsNullOrEmpty(reference)).ToList();

            if(externalReferences.Count != externalReferences.Distinct().Count()) throw new Exception("Se encontraron external_reference duplicados en la lista de comprobantes.");

            //No permite comprobantes de tipo E
            if(billReq.Receipts.Select(x => x.Receipt).Any(x => x.Tipo.Contains("E"))) throw new InvalidOperationException("No puede enviar comprobantes de Tipo E.");

            #endregion

            var result = await this.restClient.PostAsync($"{CONTROLLER_NAME}/lotes_encola", base.ToJson<BillingAsyncBatchRequest>(billReq));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<BillingBatchResponse>(result.Response);
            }

            //response.statusCode = result.StatusCode;

            if (result.StatusCode != STATUS_CREATED)
            {
                throw new Exception(result.StatusCode.ToString());
            }

            return response;
        }

        public async Task<BillingResponse> BillingAsyncOne(BillingAsyncOneRequest billReq)
        {
            var response = new BillingResponse();

            billReq.ApiKey = _apiKey;
            billReq.ApiToken = _apiToken;
            billReq.UserToken = _userToken;

            var result = await this.restClient.PostAsync($"{CONTROLLER_NAME}/nuevo_encola", base.ToJson<BillingAsyncOneRequest>(billReq));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<BillingResponse>(result.Response);
            }

            if (response.Error?.Contains("S") == true)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(result.Response);

                throw new ResponseException(errorResponse);
            }

            return response;
        }
    }
}
