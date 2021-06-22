using GCS.ERP.Identidade.MVC.Extensions;
using GCS.ERP.Identidade.MVC.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GCS.ERP.Identidade.MVC.Configuracoes
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IServicoAutenticacao, ServicoAutenticacao>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuario, UsuarioAspNet>();
        }
    }
}