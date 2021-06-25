using System;

namespace GCS.ERP.Core.Classes
{
    public abstract class GCSEntity
    {
        public GCSEntity()
            => IdInterno = GerarNovoId();

        public Guid IdInterno { get; set; }

        public static Guid GerarNovoId()
            => Guid.NewGuid();
    }
}
