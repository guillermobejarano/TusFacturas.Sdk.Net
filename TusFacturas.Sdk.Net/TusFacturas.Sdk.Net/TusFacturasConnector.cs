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
        public string version = "2";

        private const string endPointSandbox = "https://www.tusfacturas.app/app/api/v2/";

        private const string endPointProd = "https://www.tusfacturas.app/app/api/v2/";
        #endregion

        public readonly BillingService billingService;

        private string apiKey;
        private string apiToken;
        private string userToken;
        private int ambiente;
        private string endpoint;        

        public TusFacturasConnector(int ambiente, string apiKey, string apiToken, string userToken)
        {
            this.ambiente = ambiente;
            this.apiKey = apiKey;
            this.apiToken = apiToken;
            this.userToken = userToken;

            if (ambiente == EnviromentApi.ENVIROMENT_PRODUCCION) this.endpoint = endPointProd;
            else this.endpoint = endPointSandbox;

            this.billingService = new BillingService(this.endpoint, this.apiKey, this.apiToken, this.userToken);
        }
    }
}
