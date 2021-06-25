namespace GCS.ERP.Core.VO
{
    public class GCSUnidadesMedidasGrandeza
    {
        protected GCSUnidadesMedidasGrandeza()
        { }

        public GCSUnidadesMedidasGrandeza(short valor)
        {
            Valor = valor;
        }

        public short Valor { get; set; }


        public static implicit operator GCSUnidadesMedidasGrandeza(short grandeza)
            => new(grandeza);

        public static implicit operator short(GCSUnidadesMedidasGrandeza grandeza)
            => grandeza.Valor;

        public override string ToString()
            => Valor.ToString();

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            var valor = (GCSUnidadesMedidasGrandeza)obj;
            return Valor == valor;
        }

        public override int GetHashCode()
            => Valor.GetHashCode();
    }
}
