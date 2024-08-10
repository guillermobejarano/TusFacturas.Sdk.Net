using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tusfacturas.Sdk.Net.Clients;
using Tusfacturas.Sdk.Net.Model.Requests;

namespace Tusfacturas.Sdk.Net.Services
{
    internal interface IBillingService
    {
        void BillignInstantBatch();
        string BillingAsyncBatch();
        void BillignInstantOne();
        string BillingAsyncOne();
    }

    internal class BillingService : Service, IBillingService
    {
        private const string CONTROLLER_NAME = "nuevo_encola";
        private string privateApiKey;

        public BillingService(string endpoint, string privateApiKey) : base(endpoint)
        {
            this.privateApiKey = privateApiKey;

            var headers = new Dictionary<string, string>();
            headers.Add("apikey", this.privateApiKey);
            headers.Add("Cache-Control", "no-cache");

            this.restClient = new RestClient(this.endpoint, headers, CONTENT_TYPE_APP_JSON);
        }

        public void BillignInstantBatch()
        {
            throw new NotImplementedException();
        }

        public void BillignInstantOne()
        {
            throw new NotImplementedException();
        }

        public string BillingAsyncBatch()
        {
            var response = string.Empty;
            var result = this.restClient.Post($"{CONTROLLER_NAME}/lotes_encola", base.ToJson<BillingAsyncOneRequest>(new BillingAsyncOneRequest()));

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
