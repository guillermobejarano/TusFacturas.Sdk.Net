using System;
using Tusfacturas.Sdk.Net.Model.ErrorResponses;

namespace Tusfacturas.Sdk.Net.Exceptions
{
    public class ResponseException : Exception
    {
        //public ResponseException(string message) : base(message)
        //{
        //}
        public ErrorResponse ErrorResponse { get; }

        public ResponseException(ErrorResponse errorResponse)
            : base(string.Join("; ", errorResponse.Errores))
        {
            ErrorResponse = errorResponse;
        }
    }
}