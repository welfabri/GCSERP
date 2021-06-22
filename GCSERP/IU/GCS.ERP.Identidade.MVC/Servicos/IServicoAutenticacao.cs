using GCS.ERP.Identidade.MVC.Models;
using System.Threading.Tasks;

namespace GCS.ERP.Identidade.MVC.Servicos
{
    public interface IServicoAutenticacao
    {
        Task<ViewModelUsuarioRespostaLogin> Login(ViewModelUsuarioLogin usuarioLogin);

        Task<ViewModelUsuarioRespostaLogin> Registro(ViewModelUsuarioRegistro usuarioRegistro);
    }
}
