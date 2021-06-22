using System;
using System.Net;

namespace GCS.ERP.Identidade.MVC.Extensions
{
    public class ExcecaoRequisicaoHttp : Exception
    {
        public HttpStatusCode StatusCode;

        public ExcecaoRequisicaoHttp() { }

        public ExcecaoRequisicaoHttp(string message, Exception innerException)
            : base(message, innerException) { }

        public ExcecaoRequisicaoHttp(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

    }
}