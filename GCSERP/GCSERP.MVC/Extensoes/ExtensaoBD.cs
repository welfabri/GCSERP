using GCSERP.Produtos.Dados.Contextos;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GCSERP.MVC.Extensoes
{
    public static class ExtensaoBD
    {
        public static IServiceCollection AddExtensaoBD(this IServiceCollection services,
            IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("GCSERP");

            services.AddDbContext<DbContextProdutos>(
                options => options.UseSqlServer(cs, 
                    b => b.MigrationsAssembly("GCSERP.MVC")));

            return services;
        }

        public static IApplicationBuilder UseExtensaoBD(this IApplicationBuilder app)
        {
            

            return app;
        }
    }
}
