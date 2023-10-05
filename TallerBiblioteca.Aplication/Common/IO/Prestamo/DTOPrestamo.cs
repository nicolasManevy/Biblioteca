using System;

namespace TallerBiblioteca.Aplication.Common.IO.Prestamo
{
    public class DTOPrestamo
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public int SolicitanteDNI { get; set; }
    }
}
