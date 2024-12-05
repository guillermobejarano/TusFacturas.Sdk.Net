using Tusfacturas.Sdk.Net;

var connector = new TusFacturasConnector(
    0, 
    "64034", 
    "76fedd2a31c1c47a765dc14db238918a", 
    "309c781a596e0cc379f05c629afd0abd3f8690577ecdf483a1b3b670ca0766f3");

var request = new Tusfacturas.Sdk.Net.Model.Requests.BillingAsyncOneRequest
{
    Client = new Tusfacturas.Sdk.Net.Model.Client
    {
        DocumentoTipo = "DNI",
        Domicilio = "Fortin 2024",
        DocumentoNro = "33777666",
        RazonSocial = "Test ButacaUno",
        Provincia = "Buenos taires",
        Email = "email@dominio.com",
    },
    Receipt = new Tusfacturas.Sdk.Net.Model.Receipt
    {
        Rubro = "Ticketing",
        Tipo = "FACTURA C",
        Numero = "2",
        Operacion = "v",
        Detalle = new List<Tusfacturas.Sdk.Net.Model.Detalle>
        {

        }
    }
};
connector.billingService.BillignInstantOne(request);
