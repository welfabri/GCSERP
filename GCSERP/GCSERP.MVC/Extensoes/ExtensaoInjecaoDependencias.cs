using Microsoft.Extensions.DependencyInjection;

namespace GCSERP.MVC.Extensoes
{
    public static class ExtensaoInjecaoDependencias
    {
        public static IServiceCollection AddInjecaoDependencias(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ExtensaoAutoMapperProfiles));
            

            return service;
        }
    }
}
