using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TallerBiblioteca.Aplication.Common.Mapping
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AgregarMapping(this IServiceCollection services)
        {
            // https://github.com/MapsterMapper/Mapster/wiki/Dependency-Injection
            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
