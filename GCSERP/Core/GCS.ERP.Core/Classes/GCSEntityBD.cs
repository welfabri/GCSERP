using System;

namespace GCS.ERP.Core.Classes
{
    public abstract class GCSEntityBD : GCSEntity
    {
        public GCSEntityBD()
        { } //=> ListaHistorico = new List<string>();

        public int Id { get; set; }

        public string Apagado { get; set; } = "N";
        public bool FoiApagado => Apagado == "S";

        public DateTime DataInsercao { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public DateTime DataRemocao { get; protected set; }
        public string Historico { get; protected set; }
        //private List<string> ListaHistorico { get; set; }

        protected void AdicionarHistorico(Guid idUsuario, string descricao)
        {
            var mensagem = $"{{\"data\": {DateTime.Now}, \"usuario\": \"{idUsuario}\", \"valor\": \"{descricao}\"}}";

            if (!string.IsNullOrWhiteSpace(Historico))
                Historico += ",";

            Historico += mensagem;

            //ListaHistorico.Add(mensagem);
        }

        protected void AtualizarDataInsercao()
            => DataInsercao = DateTime.Now;

        protected void AtualizarDataAtualizacao()
            => DataAtualizacao = DateTime.Now;

        protected void AtualizarDataRemocao()
            => DataRemocao = DateTime.Now;

        public void Apagar()
        {
            Apagado = "S";
            AtualizarDataRemocao();
        }
    }
}
