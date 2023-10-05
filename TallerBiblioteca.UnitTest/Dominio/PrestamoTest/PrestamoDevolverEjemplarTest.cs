using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TallerBiblioteca.Domain;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.UnitTest.Dominio.PrestamoTest
{
    [TestClass]
    public class PrestamoDevolverEjemplarTest
    {
        readonly Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>();

        [TestInitialize]
        public void TestSetup()
        {
            dateTimeProvider.Setup(x => x.Now).Returns(DateTime.Now);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-10)]
        [DataRow(10)]
        [DataRow(500)]
        public void Prestamo_DevolverEjemplar_BuenasCondiciones_DeberiaSumarPuntaje(int puntajeInicial)
        {
            // Arrange
            var usuario = new Usuario();

            usuario.Puntaje = puntajeInicial;

            var prestamo = Prestamo.Prestar(new Ejemplar(), usuario, dateTimeProvider.Object);

            // Act
            const bool buenEstado = true;
            prestamo.Devolver(buenEstado, dateTimeProvider.Object);

            // Assert
            Assert.AreEqual(puntajeInicial + Constantes.Puntaje.PuntajePorEjemplarDevueltoCorrectamente,
                            usuario.Puntaje);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-10)]
        [DataRow(10)]
        [DataRow(500)]
        public void Prestamo_DevolverEjemplar_MalasCondiciones_DeberiaRestarPuntaje(int puntajeInicial)
        {
            // Arrange
            var usuario = new Usuario();

            usuario.Puntaje = puntajeInicial;

            var prestamo = Prestamo.Prestar(new Ejemplar(), usuario, dateTimeProvider.Object);

            // Act
            const bool buenEstado = false;
            prestamo.Devolver(buenEstado, dateTimeProvider.Object);

            // Assert
            Assert.AreEqual(puntajeInicial + Constantes.Puntaje.PuntajePorEjemplarEnMalasCondiciones,
                            usuario.Puntaje);
        }

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(-10, 1)]
        [DataRow(10, 1)]
        [DataRow(500, 1)]
        [DataRow(0, 7)]
        [DataRow(-10, 7)]
        [DataRow(10, 7)]
        [DataRow(500, 7)]
        public void Prestamo_DevolverEjemplar_FueraDePlazo_DeberiaRestarPuntaje_Base(int puntajeInicial,
                                                                                     int diasDeRetraso)
        {
            // Arrange
            var usuario = new Usuario();

            usuario.Puntaje = puntajeInicial;

            var prestamo = Prestamo.Prestar(new Ejemplar(), usuario, dateTimeProvider.Object);

            dateTimeProvider.Setup(x => x.Now).Returns(prestamo.FechaVencimiento.AddDays(diasDeRetraso));

            // Act
            const bool buenEstado = true;
            prestamo.Devolver(buenEstado, dateTimeProvider.Object);

            // Assert
            int puntajeEsperado = puntajeInicial
                                  + Constantes.Puntaje.PuntajePorEjemplarFueraDePlazoPorDiaDeMora
                                  * diasDeRetraso;
            Assert.AreEqual(puntajeEsperado, usuario.Puntaje);
            Assert.IsTrue(puntajeEsperado < puntajeInicial, "El puntaje debería haber decrecido");
        }
    }
}
