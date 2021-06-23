using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCS.ERP.Identidade.API.Modelos
{
    public class ViewModelUsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public ViewModelUsuarioToken UsuarioToken { get; set; }
    }

    public class ViewModelUsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ViewModelUsuarioClaim> Claims { get; set; }
    }

    public class ViewModelUsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
