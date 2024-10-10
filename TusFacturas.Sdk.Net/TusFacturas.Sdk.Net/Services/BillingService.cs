using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tusfacturas.Sdk.Net.Clients;
using Tusfacturas.Sdk.Net.Model.Requests;
using Tusfacturas.Sdk.Net.Model.Responses;

namespace Tusfacturas.Sdk.Net.Services
{
    public interface IBillingService
    {
        void BillignInstantBatch(BillingAsyncOneRequest billReq);
        string BillingAsyncBatch();
        BillingResponse BillignInstantOne(BillingAsyncOneRequest billReq);
        string BillingAsyncOne();
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

        public void BillignInstantBatch(BillingAsyncOneRequest billReq)
        {
            throw new NotImplementedException();
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

            //response.statusCode = result.StatusCode;

            if (result.StatusCode != STATUS_CREATED)
            {
                throw new Exception(result.StatusCode.ToString());
            }

            return response;
        }

        public string BillingAsyncBatch()
        {
            var response = string.Empty;
            var result = this.restClient.Post($"{CONTROLLER_NAME}/nuevo", base.ToJson<BillingAsyncOneRequest>(new BillingAsyncOneRequest()));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<string>(result.Response);
            }

            //response.statusCode = result.StatusCode;

            if (result.StatusCode != STATUS_CREATED)
            {
                throw new Exception(result.StatusCode.ToString());
            }

            return response;
        }

        public string BillingAsyncOne()
        {
            var response = string.Empty;
            var result = this.restClient.Post($"{CONTROLLER_NAME}/nuevo_encola", base.ToJson<BillingAsyncOneRequest>(new BillingAsyncOneRequest()));

            if (!string.IsNullOrEmpty(result.Response))
            {
                response = JsonConvert.DeserializeObject<string>(result.Response);
            }

            //response.statusCode = result.StatusCode;

            if (result.StatusCode != STATUS_CREATED)
            {
                throw new Exception(result.StatusCode.ToString());
            }

            return response;
        }
    }
}
