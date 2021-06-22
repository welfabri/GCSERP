namespace GCS.ERP.Identidade.API.Extensoes
{
    public class ConfiguracoesAPI
    {
        public string Segredo { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
