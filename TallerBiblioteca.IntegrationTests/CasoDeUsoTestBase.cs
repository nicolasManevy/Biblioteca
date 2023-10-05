using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Aplication.Log;
using TallerBiblioteca.Domain.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;
using TallerBiblioteca.Infrastructure;
using TallerBiblioteca.Infrastructure.DAL.EntityFramework;
using TallerBiblioteca.Infrastructure.Seguridad;

namespace TallerBiblioteca.IntegrationTests
{
    public class CasoDeUsoTestBase
    {
        public static object mutex = new object();

        private IServiceScopeFactory _scopeFactory;

        protected IServiceProvider ScopedServiceProvider => _scopeFactory.CreateScope().ServiceProvider;

        protected BibliotecaDbContext DbContext => _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<BibliotecaDbContext>();

        protected IUnitOfWorkFactory UnitOfWorkFactory => _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWorkFactory>();

        protected Mock<IDateTimeProvider> DateTimeProviderMock = new Mock<IDateTimeProvider>();

        [TestInitialize]
        public void TestSetup()
        {
            Monitor.Enter(mutex);

            LogManager.Initialize();

            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AgregarAplicacion()
                            .AgregarLibrosRemotos()
                            .AgregarPersistencia();

                    services.AddSingleton<IHashingManager, HashingManager>();

                    services.AddSingleton(DateTimeProviderMock.Object);
                }).Build();

            _scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            DbContext.Database.Delete();
            DbContext.Database.CreateIfNotExists();

            var sistema = host.Services.GetRequiredService<InicioSistema>();
            sistema.Inicio();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Monitor.Exit(mutex);
        }

        protected Usuario GenerarUsuario(int dni)
        {
            Usuario usuario = Usuario.Crear(new CrearUsuarioDTO()
            {
                Dni = dni,
                NombreUsuario = "pepe",
                EsAdminitrador = false,
                Mail = dni + "@gmail.com",
                Password = "123456"
            }, new HashingManager(), DateTimeProviderMock.Object);

            return usuario;
        }

        protected Edicion GenerarEdicion(string isbn)
        {
            var edicion = new Edicion()
            {
                Titulo = "titulo",
                Isbn = isbn,
                AñoEdicion = 1990,
                Publicacion = "editorial",
                Autores = "autor",
                DatosAdicionales = "",
                Descripcion = "",
                NumeroPaginas = 1,
                Portada = "portada",
            };

            return edicion;
        }

        protected Ejemplar GenerarEjemplar(Edicion edicion)
        {
            var ejemplar = new Ejemplar()
            {
                Edicion = edicion,
                FechaAlta = DateTimeProviderMock.Object.Now,
            };

            return ejemplar;
        }
    }
}