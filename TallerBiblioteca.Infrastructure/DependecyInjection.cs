using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Aplication.LibrosRemotos;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;
using TallerBiblioteca.Infrastructure.DAL.EntityFramework;
using TallerBiblioteca.Infrastructure.LibrosRemotos.OpenLibrary;
using TallerBiblioteca.Infrastructure.Seguridad;
using TallerBiblioteca.Infrastructure.Tareas.Quartz;
using TallerBiblioteca.Infrastructure.Tiempo;

namespace TallerBiblioteca.Infrastructure
{
    public static partial class DependecyInjection
    {
        public static IServiceCollection AgregarInfrastructura(this IServiceCollection services)
        {
            AgregarPersistencia(services);
            AgregarLibrosRemotos(services);
            AgregarPersistencia(services);
            AgregarTiempo(services);
            AgregarQuartz(services);

            services.AddSingleton<IHashingManager, HashingManager>();

            // HttpClient
            services.AddHttpClient("OpenLibrary", client =>
            {
                client.BaseAddress = new Uri("https://openlibrary.org/");
            });

            return services;
        }

        public static IServiceCollection AgregarLibrosRemotos(this IServiceCollection servicios)
        {
            servicios.AddTransient<IServicioEdicionRemota, ServicioEdicionRemota>();
            return servicios;
        }

        public static IServiceCollection AgregarPersistencia(this IServiceCollection servicios)
        {
            // DbContext
            servicios.AddScoped<BibliotecaDbContext>();
            // UnitOfWork
            servicios.AddScoped<IUnitOfWork, UnitOfWork>();
            servicios.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            // Repositorios
            servicios.AddScoped<IRepositorioEjemplar, RepositorioEjemplares>();
            servicios.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
            servicios.AddScoped<IRepositorioUsuario, RepositorioUsuarios>();
            servicios.AddScoped<IRepositorioEdicion, RepositorioEdiciones>();
            servicios.AddScoped<IRepositorioNotificacionVencimientoPrestamo, RepositorioNotificacionVencimientoPrestamo>();

            return servicios;
        }

        public static IServiceCollection AgregarTiempo(this IServiceCollection servicios)
        {
            servicios.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return servicios;
        }

        public static IServiceCollection AgregarQuartz(this IServiceCollection servicios)
        {
            servicios.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                q.AddJob<TareaEnviarAvisoADosDiasVencimiento>(opt =>
                        opt.WithIdentity(TareaEnviarAvisoADosDiasVencimiento.Key)
                ).AddTrigger(opt =>
                {
                    opt
                        .ForJob(TareaEnviarAvisoADosDiasVencimiento.Key)
                        .WithIdentity(nameof(TareaEnviarAvisoADosDiasVencimiento) + "-trigger")
                        .WithSimpleSchedule(x => x
                            .WithIntervalInHours(5)
                            .RepeatForever())
                        .StartNow();
                });
            });

            servicios.AddQuartzHostedService(q =>
            {
                q.WaitForJobsToComplete = true;
            });

            return servicios;
        }
    }
}
