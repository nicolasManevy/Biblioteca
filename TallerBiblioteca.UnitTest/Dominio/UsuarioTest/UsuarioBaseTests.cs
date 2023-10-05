using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.UnitTest.Dominio.UsuarioTest
{
    public class UsuarioBaseTests
    {
        protected readonly Mock<IHashingManager> hashingManager = new Mock<IHashingManager>();
        protected readonly Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>();

        [TestInitialize]
        public void TestSetup()
        {
            hashingManager.Setup(x => x.Hash(It.IsAny<string>(), It.IsAny<int>()))
                          .Returns("hash");
            dateTimeProvider.Setup(x => x.Now).Returns(DateTime.Now);
        }
    }
}
