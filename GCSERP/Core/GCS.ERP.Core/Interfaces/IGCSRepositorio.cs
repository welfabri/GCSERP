using System;

namespace GCS.ERP.Core.Interfaces
{
    public interface IGCSRepositorio<T> : IDisposable
        where T : IGSEntidadeAgregacao
    {
    }
}
