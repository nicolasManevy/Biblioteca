using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TallerBiblioteca.Aplication.LibrosRemotos;
using TallerBiblioteca.Infrastructure.LibrosRemotos.OpenLibrary;

namespace TallerBiblioteca.UnitTest.Servicios.LibrosRemotos
{
    [TestClass]
    public class OpenLibraryEdicionServicioTests
    {
        private readonly MockHttpMessageHandler mMockHttpMessageHandler = new MockHttpMessageHandler();

        [TestMethod]
        public async Task BuscarPorISBN_StatusCodeNotOk_DevuelveNull()
        {
            // Arrange
            string ISBN = "978-0-9767736-6-5";

            mMockHttpMessageHandler.When("*").Respond(System.Net.HttpStatusCode.BadRequest);

            var cliente = new HttpClient(mMockHttpMessageHandler);
            var clienteFactory = new Mock<IHttpClientFactory>();
            clienteFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(cliente);

            IServicioEdicionRemota servicio = new ServicioEdicionRemota(clienteFactory.Object);

            // Assert
            Assert.IsNull(await servicio.BuscarPorISBNAsync(ISBN));
        }

        [TestMethod]
        public async Task BuscarPorISBN_MimeNoJson_DevuelveNull()
        {
            // Arrange
            string ISBN = "978-0-9767736-6-5";

            mMockHttpMessageHandler.When("*").Respond(System.Net.HttpStatusCode.OK, "application/text", "");

            var cliente = new HttpClient(mMockHttpMessageHandler);

            var clienteFactory = new Mock<IHttpClientFactory>();
            clienteFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(cliente);

            IServicioEdicionRemota servicio = new ServicioEdicionRemota(clienteFactory.Object);


            // Assert
            Assert.IsNull(await servicio.BuscarPorISBNAsync(ISBN));
        }

        [TestMethod]
        public async Task BuscarPorISBN_RespuestaInvalida_DevuelveNull()
        {
            // Arrange
            string ISBN = "978-0-9767736-6-5";

            mMockHttpMessageHandler.When("*").Respond(System.Net.HttpStatusCode.OK, "application/json", "");

            var cliente = new HttpClient(mMockHttpMessageHandler);

            var clienteFactory = new Mock<IHttpClientFactory>();
            clienteFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(cliente);

            IServicioEdicionRemota servicio = new ServicioEdicionRemota(clienteFactory.Object);


            // Assert
            Assert.IsNull(await servicio.BuscarPorISBNAsync(ISBN));
        }

        [TestMethod]
        public async Task BuscarPorISBN_RespuestaValidaConClave_DevuelveEdicion()
        {
            // Arrange
            string ISBN = "978-0-9767736-6-5";
            string llave = String.Format("ISBN:{0}", ISBN);

            var respuesta = JsonContent.Create(
                new Dictionary<string, object>
                {
                    {
                        llave,
                        new
                        {
                            publishers = new[] {
                                new {
                                    name = "Pragmatic Bookshelf"
                                }
                            },
                            pagination = "xviii, 214 p. :",
                            identifiers = new
                            {
                                lccn = new[] {
                                    "2006926216"
                                },
                                openlibrary = new[] {
                                    "OL17944377M"
                                },
                                isbn_10 = new[] {
                                    "0976773667"
                                },
                                librarything = new[] {
                                    "LCCN2006926216"
                                },
                                goodreads = new[] {
                                    "1860744894"
                                },
                                isbn_13 = new[] {
                                    "9780976773665"
                                }
                            },
                            subtitle = "a pragmatic guide to the Java persistence API",
                            title = "Pro JPA",
                            url = "https://openlibrary.org/books/OL17944377M/Pro_JPA",
                            notes = "Includes index.",
                            number_of_pages = 214,
                            cover = new
                            {
                                small = "https://covers.openlibrary.org/b/id/233604-S.jpg",
                                large = "https://covers.openlibrary.org/b/id/233604-L.jpg",
                                medium = "https://covers.openlibrary.org/b/id/233604-M.jpg"
                            },
                            publish_date = "2007",
                            key = "/books/OL17944377M",
                            authors = new[] {
                                new {
                                    url = "https://openlibrary.org/authors/OL139960A/Mike_Keith",
                                    name = "Mike Keith"
                                },
                                new {
                                    url = "https://openlibrary.org/authors/OL139961A/Merrick_Schincariol",
                                    name = "Merrick Schincariol"
                                }
                            },
                            subjects = new[] {
                                new {
                                    url = "https://openlibrary.org/subjects/java_persistence_api",
                                    name = "Java Persistence API"
                                },
                                new {
                                    url = "https://openlibrary.org/subjects/object-relational_mapping",
                                    name = "Object-relational mapping"
                                },
                                new {
                                    url = "https://openlibrary.org/subjects/java_(computer_program_language)",
                                    name = "Java (Computer program language)"
                                }
                            }
                        }
                    }
                }
            );

            mMockHttpMessageHandler.When("*").Respond(System.Net.HttpStatusCode.OK, respuesta);

            var cliente = new HttpClient(mMockHttpMessageHandler)
            {
                BaseAddress = new Uri("https://openlibrary.org")
            };

            var clienteFactory = new Mock<IHttpClientFactory>();
            clienteFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(cliente);

            IServicioEdicionRemota servicio = new ServicioEdicionRemota(clienteFactory.Object);


            // Act
            var edicion = await servicio.BuscarPorISBNAsync(ISBN);

            // Assert
            Assert.IsNotNull(edicion);
            Assert.AreEqual("978-0-9767736-6-5", edicion.Isbn);
            Assert.AreEqual(2007, edicion.AñoEdicion);
            Assert.AreEqual(214, edicion.NumeroPaginas);
            Assert.AreEqual("Pro JPA", edicion.Titulo);
            Assert.AreEqual("a pragmatic guide to the Java persistence API", edicion.Descripcion);
            Assert.IsNotNull(edicion.Portada);
            Assert.IsTrue(edicion.Portada.Length > 0);
            Assert.AreEqual("Mike Keith, Merrick Schincariol", edicion.Autores);
        }

        [TestMethod]
        public async Task BuscarPorISBN_RespuestaVacía_DevuelveNull()
        {
            // Arrange
            string ISBN = "978-0-9767736-6-5";
            var respuesta = JsonContent.Create(
                new Dictionary<string, object>
                {
                }
            );

            mMockHttpMessageHandler.When("*").Respond(System.Net.HttpStatusCode.OK, respuesta);

            var cliente = new HttpClient(mMockHttpMessageHandler)
            {
                BaseAddress = new Uri("https://openlibrary.org")
            };

            var clienteFactory = new Mock<IHttpClientFactory>();
            clienteFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(cliente);

            IServicioEdicionRemota servicio = new ServicioEdicionRemota(clienteFactory.Object);

            // Act
            var edicion = await servicio.BuscarPorISBNAsync(ISBN);

            // Assert
            Assert.IsNull(edicion);
        }
    }
}
