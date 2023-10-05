using Microsoft.Extensions.DependencyInjection;
using TallerBiblioteca.Aplication.Common.Mapping;

namespace TallerBiblioteca.Aplication
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
        {
            services.AddScoped<FachadaUsuarios>();
            services.AddScoped<FachadaEdicion>();
            services.AddScoped<FachadaEjemplar>();
            services.AddScoped<FachadaPrestamo>();

            services.AddScoped<InicioSistema>();

            services.AgregarMapping();

            return services;
        }
    }
}
