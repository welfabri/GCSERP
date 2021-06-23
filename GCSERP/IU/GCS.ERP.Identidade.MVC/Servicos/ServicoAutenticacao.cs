using GCS.ERP.Identidade.MVC.Extensions;
using GCS.ERP.Identidade.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GCS.ERP.Identidade.MVC.Servicos
{
    public class ServicoAutenticacao : ServicoBase, IServicoAutenticacao
    {
        private readonly HttpClient _httpClient;

        public ServicoAutenticacao(HttpClient httpClient,
                                   IOptions<ConfiguracoesMVC> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);

            _httpClient = httpClient;
        }

        public async Task<ViewModelUsuarioRespostaLogin> Login(ViewModelUsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new ViewModelUsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            
            var r = await DeserializarObjetoResponse<ViewModelUsuarioRespostaLogin>(response);
            return r;
        }

        public async Task<ViewModelUsuarioRespostaLogin> Registro(ViewModelUsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new ViewModelUsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            var r = await DeserializarObjetoResponse<ViewModelUsuarioRespostaLogin>(response);
            return r;
        }
    }
}
