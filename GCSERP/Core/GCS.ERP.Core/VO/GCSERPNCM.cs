using GCS.ERP.Core.Excecao;

namespace GCS.ERP.Core.VO
{
    public class GCSERPNCM
    {
        public const byte TAMANHO = 8;

        protected GCSERPNCM() { }

        protected GCSERPNCM (int ncm)
            : this()
            => Valor = ncm;

        public int Valor { get; set; }

        public bool EValido()
            => (Valor.ToString().Length == TAMANHO);

        public override string ToString()
            => Valor.ToString();



        public static implicit operator GCSERPNCM(int ncm)
            => CriaNCMInt(ncm);

        public static implicit operator int(GCSERPNCM ncm)
            => ncm.Valor;

        public static implicit operator GCSERPNCM(string ncm)
            => CriaNCMString(ncm);

        private static GCSERPNCM CriaNCMInt(int ncm)
        {
            GCSERPNCM result = new(ncm);

            if (!result.EValido())
                throw new ExcecaoDominio($"NCM inválido: {ncm}");

            return result;
        }

        private static GCSERPNCM CriaNCMString(string ncm)
        {
            ncm = ncm.Replace(".", string.Empty);

            var valido = int.TryParse(ncm, out var i);

            if (!valido)
                throw new ExcecaoDominio($"NCM inválido: {ncm}");

            return CriaNCMInt(i);
        }
    }
}
