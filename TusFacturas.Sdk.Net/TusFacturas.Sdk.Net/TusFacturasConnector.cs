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

        private readonly BillingService billingService;

        private string privateApiKey;
        private string publicApiKey;
        private int ambiente;
        private string endpoint;        

        public TusFacturasConnector(int ambiente, string privateApiKey, string publicApiKey)
        {
            this.ambiente = ambiente;
            this.privateApiKey = privateApiKey;
            this.publicApiKey = publicApiKey;

            if (ambiente == EnviromentApi.ENVIROMENT_PRODUCCION) this.endpoint = endPointProd;
            else this.endpoint = endPointSandbox;

            this.billingService = new BillingService(this.endpoint, this.privateApiKey);
        }
    }
}
