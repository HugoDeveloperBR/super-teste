using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SuperTest.ApplicationService;
using SuperTest.Domain.Repositories.Usuarios;
using SuperTest.Domain.Services;
using SuperTest.Infra.Repository.Data;

namespace SuperTest.Infra.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterDependency(IServiceCollection services)
        {
            //App Service
            services.AddScoped<IUsuarioService, UsuarioAppService>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
