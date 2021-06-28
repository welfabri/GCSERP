namespace GCS.ERP.Core.Classes
{
    public abstract class GCSEntityBDCadastro : GCSEntityBD
    {
        public string CodigoExterno { get; set; }
        public byte VersaoInterna { get; set; } = 1;
        public bool Ativo { get; set; } = true;
    }
}
