using System;

namespace TallerBiblioteca.Aplication.Common.IO.Prestamo
{
    public class DTOPrestamoConUsuarioYEjemplar
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Nombre { get; set; }
        public int IdEjemplar { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
