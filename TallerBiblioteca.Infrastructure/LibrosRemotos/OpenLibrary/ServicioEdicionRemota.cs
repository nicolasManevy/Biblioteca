using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Aplication.LibrosRemotos;
using TallerBiblioteca.Aplication.Log;
using TallerBiblioteca.Infrastructure.Common.JSON;

namespace TallerBiblioteca.Infrastructure.LibrosRemotos.OpenLibrary
{
    public class ServicioEdicionRemota : IServicioEdicionRemota
    {
        private readonly HttpClient mCliente;

        public ServicioEdicionRemota(IHttpClientFactory pClienteFactory)
        {
            mCliente = pClienteFactory.CreateClient("OpenLibrary");
        }

        public async Task<DTOEdicion> BuscarPorISBNAsync(string pIsbn)
        {
            try
            {
                var respuesta = await mCliente.GetAsync($"api/books?bibkeys=ISBN:{pIsbn}&jscmd=data&format=json");

                if (!respuesta.IsSuccessStatusCode)
                {
                    LogManager.GetLogger().Error("No se puede realizar la consulta en el servidor");
                }

                if (respuesta.Content.Headers.ContentType.MediaType != "application/json")
                {
                    LogManager.GetLogger().Error("Respuesta invalida");
                }

                var bodyJson = await respuesta.Content.ReadAsStringAsync();
                var cuerpo = JObject.Parse(bodyJson);

                if (cuerpo == null || cuerpo.Count == 0)
                {
                    return null;
                }

                DTOEdicion edicion = ConvertirEdicionDesdeJsonData(pIsbn, cuerpo);

                return edicion;
            } catch (Exception e)
            {
                LogManager.GetLogger().Error(e, "Error desconocido");
            }

            return null;
        }

        private DTOEdicion ConvertirEdicionDesdeJsonData(string isbn, JObject cuerpo)
        {
            if (cuerpo == null)
            {
                return null;
            }

            // implementacion para convertir el json especificado aqui en un DTOEdicion
            // https://openlibrary.org/dev/docs/api/books#:~:text=books/OL23377687M/adventures_of_Tom_Sawyer%22%0A%20%20%20%20%7D%0A%7D-,jscmd%3Ddata,-When%20the%20jscmd
            DTOEdicion edicion = new DTOEdicion();

            cuerpo = (JObject)cuerpo[$"ISBN:{isbn}"];

            edicion.Titulo = cuerpo.GetOptional<string>("title", "");
            edicion.Descripcion = cuerpo.GetOptional<string>("subtitle", "");

            edicion.Isbn = isbn;
            edicion.NumeroPaginas = cuerpo.GetOptional<int>("number_of_pages", 0);

            if (cuerpo.ContainsKey("authors"))
            {
                edicion.Autores = string.Join(", ", cuerpo["authors"].Select(a => (string)a["name"]));
            }

            if (cuerpo.ContainsKey("publish_date"))
            {
                string fechaString = (string)cuerpo["publish_date"];
                try
                {
                    DateTime fechaPublicacion = PasarFecha(fechaString, new CultureInfo("en-US"));

                    edicion.Publicacion = fechaPublicacion.ToString("dd/MM/yyyy");

                    edicion.AñoEdicion = fechaPublicacion.Year;
                } catch (FormatException ex)
                {
                    // Error fecha invalida
                    LogManager.GetLogger().Error(ex, "Error: Fecha invalida '{0}'. {1}", fechaString, ex.Message);
                }
            }

            if (cuerpo.ContainsKey("publishers"))
            {
                string publicadores = string.Join(", ", cuerpo["publishers"].Select(a => (string)a["name"]));
                edicion.Publicacion = publicadores + ";" + edicion.Publicacion;
            }

            edicion.Portada = $"https://covers.openlibrary.org/b/isbn/{isbn}-M.jpg";

            return edicion;
        }

        private static DateTime PasarFecha(string fecha, CultureInfo cultureInfo)
        {
            DateTime date;
            string procesada = fecha;

            if (cultureInfo.TwoLetterISOLanguageName == "en")
            {
                procesada = fecha.Replace("nd", "")
                             .Replace("th", "")
                             .Replace("rd", "")
                             .Replace("st", "");
            }

            List<string> formatos = new List<string>(){
                "MMMM d, yyyy",
                "MMMM d yyyy",
                "MMM dd, yyyy",
                "MMMM dd yyyy",
                "MMMM yyyy",
                "yyyy",
                "yyyy?",
                "yyyy MMMM",
                "yyyy MMMM d",
                "yyyy MMMM dd",
                "yyyy-MM-dd",
                "yyyy-MM-dd",
                "yyyy-MM-dd",
            };

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings?redirectedfrom=MSDN
            foreach (var formato in formatos)
            {
                if (DateTime.TryParseExact(fecha, formato, cultureInfo, DateTimeStyles.None, out date))
                {
                    return date;
                }
            }

            throw new FormatException("Formato de fecha desconocido.");
        }
    }
}
