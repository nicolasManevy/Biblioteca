using System;
using TallerBiblioteca.Domain.Common.Excepciones;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Domain.Modelos
{
    public class Prestamo : Entidad
    {
        public virtual Usuario Solicitante { get; set; }
        public virtual Ejemplar Ejemplar { get; set; }

        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public void Devolver(bool enBuenEstado, IDateTimeProvider dateTimeProvider)
        {
            if (FechaDevolucion != null)
                return;

            FechaDevolucion = dateTimeProvider.Now;

            if (!enBuenEstado)
            {
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarEnMalasCondiciones;
            }

            int diasMora = (int)(dateTimeProvider.Now - FechaVencimiento).TotalDays;
            if (diasMora > 0)
            {
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarFueraDePlazoPorDiaDeMora * diasMora;
            }

            if (enBuenEstado && diasMora <= 0)
            {
                Solicitante.Puntaje += Constantes.Puntaje.PuntajePorEjemplarDevueltoCorrectamente;
            }
        }

        /// <summary>
        /// Crea un prestamo y asegura que las reglas del negocio sean aplicadas
        /// correctamente
        /// </summary>
        /// <param name="ejemplar">ejemplar a prestar</param>
        /// <param name="solicitante">usuario que solicitó el prestamo</param>
        /// <param name="dateTimeProvider">proveedor de la fecha</param>
        /// <returns></returns>
        public static Prestamo Prestar(Ejemplar ejemplar,
                                       Usuario solicitante,
                                       IDateTimeProvider dateTimeProvider)
        {
            if (ejemplar.FechaBaja != null)
            {
                throw new EjemplarEstaDadoDeBaja();
            }

            int diasAPrestar = solicitante.MaximoDiasHabilesPrestamos();

            DateTime fechaVencimiento = dateTimeProvider.Now.AddDays(diasAPrestar);

            return new Prestamo()
            {
                Ejemplar = ejemplar,
                Solicitante = solicitante,
                FechaPrestamo = dateTimeProvider.Now,
                FechaVencimiento = fechaVencimiento,
            };
        }
    }
}
