using System;
using System.Collections.Generic;
using System.Text;

namespace Tusfacturas.Sdk.Net.Model.ErrorResponses
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public List<string> Errores { get; set; }
        public string ExternalReference { get; set; }
        public List<string> ErrorCod { get; set; }
        public List<ErrorDetail> ErrorDetails { get; set; }
    }

    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}
