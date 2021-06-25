using System.Threading.Tasks;

namespace GCS.ERP.Core.Interfaces
{
    public interface IGCSUnityOfWork
    {
        Task<bool> CommitAsync();
    }
}
