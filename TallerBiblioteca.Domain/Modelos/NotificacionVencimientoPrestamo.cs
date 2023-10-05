using System;

namespace TallerBiblioteca.Domain.Modelos
{
    public class NotificacionVencimientoPrestamo : Entidad
    {
        public DateTime FechaEnvio { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
