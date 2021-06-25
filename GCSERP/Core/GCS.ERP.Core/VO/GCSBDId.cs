using System;

namespace GCS.ERP.Core.VO
{
    public class GCSBDId
    {
        protected GCSBDId()
        { }

        protected GCSBDId(Guid id)
            => Id = id;

        public Guid Id { get; set; }

        //public static implicit operator GCSBDId(string id)
        //    => new(Guid.Parse(id));

        //public static implicit operator GCSBDId(Guid id)
        //    => new(id);

        public static implicit operator Guid(GCSBDId id)
            => id.Id;

        public static implicit operator GCSBDId(Guid id)
            => new(id);

        //public static explicit operator GCSBDId(Guid id)
        //    => new(id);

        public bool EValido()
            => !string.IsNullOrWhiteSpace(Id.ToString());

        public override string ToString()
            => Id.ToString();

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            var id = (GCSBDId)obj;
            return Id == id;
        }

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
