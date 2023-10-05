using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TallerBiblioteca.Domain.Common.Excepciones;
using TallerBiblioteca.Domain.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.UnitTest.Dominio.UsuarioTest
{
    [TestClass]
    public class UsuarioCrearTest : UsuarioBaseTests
    {

        [TestMethod]
        public void UsuarioCrear_Exitoso()
        {
            // Arrange
            var solicitud = new CrearUsuarioDTO()
            {
                NombreUsuario = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            };

            // Act
            var usuario = Usuario.Crear(solicitud,
                                        hashingManager.Object,
                                        dateTimeProvider.Object);

            // Assert
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void UsuarioCrear_EmailInvalido_TiraError()
        {
            // 
            var solicitud = new CrearUsuarioDTO()
            {
                NombreUsuario = "Juan",
                Mail = "123",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            };

            // 
            Assert.ThrowsException<ExcepcionEmailInvalido>(() => Usuario.Crear(solicitud,
                                                                               hashingManager.Object,
                                                                               dateTimeProvider.Object));
        }

        [TestMethod]
        public void UsuarioCrear_PasswordInvalido_TiraError()
        {
            // Arrange
            var solicitud = new CrearUsuarioDTO()
            {
                NombreUsuario = "Juan",
                Mail = "juan@gmail.com",
                Password = "",
                Dni = 12345678,
                EsAdminitrador = false
            };

            // Assert
            Assert.ThrowsException<ArgumentException>(() => Usuario.Crear(solicitud,
                                                                          hashingManager.Object,
                                                                          dateTimeProvider.Object));
        }

        [TestMethod]
        public void UsuarioCrear_HasheaPassword()
        {
            // Arrange
            var solicitud = new CrearUsuarioDTO()
            {
                NombreUsuario = "Juan",
                Mail = "juan@gmail.com",
                Password = "password",
                Dni = 12345678,
                EsAdminitrador = false
            };

            // Act
            var usuario = Usuario.Crear(solicitud,
                                        hashingManager.Object,
                                        dateTimeProvider.Object);

            // Assert
            hashingManager.Verify(x => x.Hash(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }
    }
}
