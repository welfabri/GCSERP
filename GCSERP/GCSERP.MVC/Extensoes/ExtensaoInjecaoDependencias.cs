using GCSERP.Produtos.Dados.Repostiorios;
using GCSERP.Produtos.Entidades.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GCSERP.MVC.Extensoes
{
    public static class ExtensaoInjecaoDependencias
    {
        public static IServiceCollection AddInjecaoDependencias(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ExtensaoAutoMapperProfiles));

            service.AddScoped<IRepositorioProdutos, RepostiorioProdutos>();
            service.AddScoped<IRepositorioProdutosClassificacoes, RepostiorioProdutosClassificacoes>();


            return service;
        }
    }
}
