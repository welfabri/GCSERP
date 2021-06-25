using System;

namespace GCS.ERP.Core.Excecao
{
    public class ExcecaoDominio : Exception
    {
        public ExcecaoDominio()
            : base() { }

        public ExcecaoDominio(string mensagem)
            : base(mensagem) { }

        public ExcecaoDominio(string mensagem, Exception innerException)
            : base(mensagem, innerException) { }
    }
}
