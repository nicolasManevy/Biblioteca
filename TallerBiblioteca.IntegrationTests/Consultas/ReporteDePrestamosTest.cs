using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TallerBiblioteca.Domain;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.IntegrationTests
{
    [TestClass]
    public class ReporteDePrestamosTest : CasoDeUsoTestBase
    {
        [TestMethod]
        public void ReporteDePrestamos_ProximosAVencer()
        {
            // Arrange
            Usuario usuario = GenerarUsuario(dni: 12345678);

            Edicion edicion = GenerarEdicion(isbn: "isbn");

            Ejemplar ejemplar1 = GenerarEjemplar(edicion);
            Ejemplar ejemplar2 = GenerarEjemplar(edicion);
            Ejemplar ejemplar3 = GenerarEjemplar(edicion);

            var diasBase = Constantes.Prestamo.DiasBaseDePrestamo;

            // dentro de fecha -> vencimiento = ahora + diasBase
            var prestamo1 = Prestamo.Prestar(ejemplar1, usuario, DateTimeProviderMock.Object);

            // fuera
            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now.AddDays(diasBase + 12));
            var prestamo2 = Prestamo.Prestar(ejemplar2, usuario, DateTimeProviderMock.Object);

            DateTimeProviderMock.Setup(x => x.Now).Returns(DateTime.Now); // reset

            // devuelto
            var prestamo3 = Prestamo.Prestar(ejemplar3, usuario, DateTimeProviderMock.Object);
            prestamo3.Devolver(true, DateTimeProviderMock.Object);

            using (var unit = UnitOfWorkFactory.Crear())
            {
                unit.RepositorioUsuarios.Agregar(usuario);

                unit.RepositorioEdiciones.Agregar(edicion);

                unit.RepositorioEjemplares.Agregar(ejemplar1);
                unit.RepositorioEjemplares.Agregar(ejemplar2);
                unit.RepositorioEjemplares.Agregar(ejemplar3);

                unit.RepositorioPrestamos.Agregar(prestamo1);
                unit.RepositorioPrestamos.Agregar(prestamo2);
                unit.RepositorioPrestamos.Agregar(prestamo3);

                unit.Commit();
            }

            // Act
            DateTime limite = DateTimeProviderMock.Object.Now.AddDays(diasBase + 5);
            var reporte = UnitOfWorkFactory.Crear().RepositorioPrestamos.ObtenerProximoAVencer(limite);

            // Assert
            Assert.AreEqual(1, reporte.Count);
            Assert.AreEqual(prestamo1.Id, reporte[0].Id);
        }
    }
}
