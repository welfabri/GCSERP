using GCSERP.MVC.Dados;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GCSERP.MVC.Extensoes
{
    public static class ExtensaoIdentidade
    {
        public static IServiceCollection AddExtensaoIdentidade(this IServiceCollection services,
            IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("GCSERP");

            services.AddDbContext<DbContextIdentidade>(
                options => options.UseSqlServer(cs));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DbContextIdentidade>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    {
                        options.LoginPath = "/entrar";
                        options.AccessDeniedPath = "/acesso-negado";
                    });

            return services;
        }

        public static IApplicationBuilder UseExtensaoIdentidade(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
