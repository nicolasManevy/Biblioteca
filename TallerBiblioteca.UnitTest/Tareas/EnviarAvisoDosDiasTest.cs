using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Aplication.Servicios.Notificacion;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Tiempo;
using TallerBiblioteca.Infrastructure.Tareas.Quartz;

namespace TallerBiblioteca.UnitTest.Tareas
{
    [TestClass]
    public class EnviarAvisoDosDiasTest
    {
        [TestMethod]
        public void EnviarAviso_LLamaAEnviarYGuardaNotificacion()
        {
            //Arrange
            var notificadorMock = new Mock<INotificador>();
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();

            var usuario = new Usuario();

            notificadorMock.Setup(library => library.Enviar(
                            It.IsAny<string>(), It.IsAny<string>(),
                            usuario))
                .Returns(true);

            dateTimeProviderMock.Setup(library => library.Now)
                .Returns(DateTime.Now);

            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var repositorioVencimientoMock = new Mock<IRepositorioNotificacionVencimientoPrestamo>();

            repositorioVencimientoMock.Setup(
                repo => repo.ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(It.IsAny<DateTime>()))
                .Returns(new List<Prestamo>() { new Prestamo()
                {
                    FechaDevolucion = dateTimeProviderMock.Object.Now.AddDays(1),
                    Solicitante = usuario
                } });


            unitOfWorkMock.Setup(unit => unit.RepositorioNotificacionVencimientoPrestamo)
                .Returns(repositorioVencimientoMock.Object);

            var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();

            unitOfWorkFactoryMock.Setup(library => library.Crear())
                .Returns(unitOfWorkMock.Object);

            var tarea = new TareaEnviarAvisoADosDiasVencimiento(
                                new List<INotificador>() { notificadorMock.Object },
                                unitOfWorkFactoryMock.Object,
                                dateTimeProviderMock.Object);

            //Act
            tarea.Execute(null);

            //Assert 
            notificadorMock.Verify(library => library.Enviar(
                            It.IsAny<string>(),
                            It.IsAny<string>(), usuario), Times.Exactly(1));

            repositorioVencimientoMock.Verify(repo => repo.Agregar(It.IsAny<NotificacionVencimientoPrestamo>()), Times.Exactly(1));

            unitOfWorkFactoryMock.Verify(repo => repo.Crear(), Times.Exactly(1));
        }
    }
}
