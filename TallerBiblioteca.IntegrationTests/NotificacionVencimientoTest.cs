using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TallerBiblioteca.Aplication.Servicios.Notificacion;
using TallerBiblioteca.Aplication.Tareas;
using TallerBiblioteca.Domain;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.IntegrationTests.Consultas
{
    [TestClass]
    public class PorVencerSinNotificarTest : CasoDeUsoTestBase
    {
        [TestInitialize]
        public new void TestSetup()
        {
            base.TestSetup();
        }

        [TestMethod]
        public void PrestamoPorVencer_DeberiaDevolver_SoloElPrestamoPorVencer()
        {
            // Arrange

            // e.g. 2 dias -> si hoy es 05/08/2000, hay que avisarles a los 
            // que venzan el [07/08/2000, 08/08/2000]
            const int diasAntelacion = 2;
            int diasBase = Constantes.Prestamo.DiasBaseDePrestamo;

            Usuario usuario = GenerarUsuario(dni: 123);

            Edicion edicion = GenerarEdicion(isbn: "333");

            Ejemplar ejemplar1 = GenerarEjemplar(edicion);
            Ejemplar ejemplar2 = GenerarEjemplar(edicion);
            Ejemplar ejemplar3 = GenerarEjemplar(edicion);

            Prestamo prestamo_notificar = Prestamo.Prestar(ejemplar1, usuario, DateTimeProviderMock.Object);

            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now.AddDays(diasBase + 12));
            Prestamo prestamo_no_notificar = Prestamo.Prestar(ejemplar2, usuario, DateTimeProviderMock.Object);

            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now); // reset

            using (var unitSetup = UnitOfWorkFactory.Crear())
            {
                unitSetup.RepositorioUsuarios.Agregar(usuario);

                unitSetup.RepositorioEdiciones.Agregar(edicion);

                unitSetup.RepositorioEjemplares.Agregar(ejemplar1);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar2);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar3);

                unitSetup.RepositorioPrestamos.Agregar(prestamo_notificar);
                unitSetup.RepositorioPrestamos.Agregar(prestamo_no_notificar);

                unitSetup.Commit();
            }

            // Act
            var unit = UnitOfWorkFactory.Crear();
            // fecha actual = fecha vencimiento del prestamo 1 - diasAntelacion
            DateTime fechaActual = DateTimeProviderMock.Object.Now.AddDays(diasBase - diasAntelacion).AddHours(2);
            var prestamosANotificar = unit.RepositorioNotificacionVencimientoPrestamo
                .ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(fechaActual);

            // Assert
            Assert.AreEqual(1, prestamosANotificar.Count);
            Assert.AreEqual(prestamo_notificar.Id, prestamosANotificar[0].Id);
        }

        // lo mismo que el test anterior pero esta vez se llama a new EnviarAvisoADosDiasVencimiento().Execute,
        // quien trae las que falta notificar, las notifica y las marca como notificadas. Por lo tanto, la proxima
        // vez que se llame a ObtenerPrestamosQueEstenPorVencerYNoSeNotifico, no deberia devolver nada.
        [TestMethod]
        public async Task PrestamoPorVencer_DeberiaNotificar_YLuegoNoDeberiaDevolverNingunoAsync()
        {
            // Arrange
            const int diasAntelacion = 2;
            int diasBase = Constantes.Prestamo.DiasBaseDePrestamo;

            Usuario usuario = GenerarUsuario(dni: 123);

            Edicion edicion = GenerarEdicion(isbn: "333");

            Ejemplar ejemplar1 = GenerarEjemplar(edicion);
            Ejemplar ejemplar2 = GenerarEjemplar(edicion);
            Ejemplar ejemplar3 = GenerarEjemplar(edicion);

            Prestamo prestamo_notificar = Prestamo.Prestar(ejemplar1, usuario, DateTimeProviderMock.Object);

            using (var unitSetup = UnitOfWorkFactory.Crear())
            {
                unitSetup.RepositorioUsuarios.Agregar(usuario);

                unitSetup.RepositorioEdiciones.Agregar(edicion);

                unitSetup.RepositorioEjemplares.Agregar(ejemplar1);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar2);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar3);

                unitSetup.RepositorioPrestamos.Agregar(prestamo_notificar);

                unitSetup.Commit();
            }

            var notificadorMock = new Mock<INotificador>();
            notificadorMock.Setup(x => x.Enviar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Usuario>()))
                            .Returns(true)
                            .Verifiable();

            DateTime fechaActual = DateTimeProviderMock.Object.Now.AddDays(diasBase - diasAntelacion).AddHours(2);
            DateTimeProviderMock.Setup(x => x.Now).Returns(fechaActual);

            var tareaEnviarAviso = new EnviarAvisosADiasDelVencimiento(new List<INotificador> { notificadorMock.Object },
                                                                       UnitOfWorkFactory,
                                                                       DateTimeProviderMock.Object);

            // Act
            await tareaEnviarAviso.Ejecutar();

            var aNotificar = UnitOfWorkFactory.Crear().RepositorioNotificacionVencimientoPrestamo
                .ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTimeProviderMock.Object.Now);

            // Assert
            notificadorMock
                .Verify(x =>
                        x.Enviar(It.IsAny<string>(),
                                         It.IsAny<string>(),
                                         It.IsAny<Usuario>()), Times.Once);
            Assert.AreEqual(0, aNotificar.Count);
        }

        // lo mismo pero si no puede notificar por algún motivo, no debería marcar como notificada.
        [TestMethod]
        public async Task PrestamoPorVencer_DeberiaNoNotificar_YLuegoNoDeberiaDevolverElPendiente()
        {
            // Arrange
            const int diasAntelacion = 2;
            int diasBase = Constantes.Prestamo.DiasBaseDePrestamo;

            Usuario usuario = GenerarUsuario(dni: 123);

            Edicion edicion = GenerarEdicion(isbn: "333");

            Ejemplar ejemplar1 = GenerarEjemplar(edicion);
            Ejemplar ejemplar2 = GenerarEjemplar(edicion);
            Ejemplar ejemplar3 = GenerarEjemplar(edicion);

            Prestamo prestamo_notificar = Prestamo.Prestar(ejemplar1, usuario, DateTimeProviderMock.Object);

            using (var unitSetup = UnitOfWorkFactory.Crear())
            {
                unitSetup.RepositorioUsuarios.Agregar(usuario);

                unitSetup.RepositorioEdiciones.Agregar(edicion);

                unitSetup.RepositorioEjemplares.Agregar(ejemplar1);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar2);
                unitSetup.RepositorioEjemplares.Agregar(ejemplar3);

                unitSetup.RepositorioPrestamos.Agregar(prestamo_notificar);

                unitSetup.Commit();
            }

            var notificadorMock = new Mock<INotificador>();
            notificadorMock.Setup(x => x.Enviar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Usuario>()))
                            .Returns(false) // no se pudo notificar
                            .Verifiable();

            DateTime fechaActual = DateTimeProviderMock.Object.Now.AddDays(diasBase - diasAntelacion).AddHours(2);
            DateTimeProviderMock.Setup(x => x.Now).Returns(fechaActual);

            var tareaEnviarAviso = new EnviarAvisosADiasDelVencimiento(new List<INotificador> { notificadorMock.Object },
                                                                       UnitOfWorkFactory,
                                                                       DateTimeProviderMock.Object);

            // Act
            await tareaEnviarAviso.Ejecutar();

            var aNotificar = UnitOfWorkFactory.Crear().RepositorioNotificacionVencimientoPrestamo
                .ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTimeProviderMock.Object.Now);

            // Assert
            notificadorMock
                .Verify(x =>
                        x.Enviar(It.IsAny<string>(),
                                         It.IsAny<string>(),
                                         It.IsAny<Usuario>()), Times.Once);

            Assert.AreEqual(1, aNotificar.Count);

            // TODO: verificar que se registro el error en el logger
        }

        // NOTA: Testear cuando se utilizan diferentes dias de antelación está fuera del alcance actualmente.
    }
}
