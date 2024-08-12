using System;

namespace Tusfacturas.Sdk.Net.Exceptions
{
    public class ResponseException : Exception
    {
        public ResponseException(string message) : base(message)
        {
        }
    }
}