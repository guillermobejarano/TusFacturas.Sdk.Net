using System;
using Tusfacturas.Sdk.Net.Services;

namespace Tusfacturas.Sdk.Net
{
    public sealed class EnviromentApi
    {
        public const int ENVIROMENT_SANDBOX = 0;
        public const int ENVIROMENT_PRODUCCION = 1;
    }

    public class TusFacturasConnector
    {
        #region Constants
        public const string version = "1";

        private const string endPointSandbox = "urlTesting";

        private const string endPointProd = "urlProd";
        #endregion

        private string privateApiKey;
        private string publicApiKey;
        private int ambiente;
        private string endpoint;

        //private HealthCheck healthCheckService;
        private BillingService billingService;

        public TusFacturasConnector(int ambiente, string privateApiKey, string publicApiKey)
        {
            this.ambiente = ambiente;
            this.privateApiKey = privateApiKey;
            this.publicApiKey = publicApiKey;

            if (ambiente == EnviromentApi.ENVIROMENT_PRODUCCION)
            {
                this.endpoint = endPointProd;
            }
            else
            {
                this.endpoint = endPointSandbox;
            }

            //this.healthCheckService = new HealthCheck(this.endpoint);
            this.billingService = new BillingService(this.endpoint, this.privateApiKey);
        }

        //public HealthCheckResponse HealthCheck()
        //{
        //    return this.healthCheckService.Execute();
        //}

        //public PaymentResponse Payment(Payment payment)
        //{
        //    return this.paymentService.ExecutePayment(payment);
        //}
    }
}
