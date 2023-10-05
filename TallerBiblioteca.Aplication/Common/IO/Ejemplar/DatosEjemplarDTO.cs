using System;
using TallerBiblioteca.Aplication.Common.IO.Edicion;

namespace TallerBiblioteca.Aplication.Common.IO.Ejemplar
{
    public class DatosEjemplarDTO
    {
        public int Id { get; set; }
        public DTOEdicion Edicion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// Si el ejemplar esta prestad o no
        /// </summary>
        public bool Prestado { get; set; }

        /// <summary>
        /// A quien se lo prestó
        /// </summary>
        public string PrestadoA { get; set; }
    }
}
