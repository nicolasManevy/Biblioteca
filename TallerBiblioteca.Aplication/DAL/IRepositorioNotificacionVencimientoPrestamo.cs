using System;
using System.Collections.Generic;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.DAL
{
    public interface IRepositorioNotificacionVencimientoPrestamo : IRepositorio<NotificacionVencimientoPrestamo>
    {
        /// <summary>
        /// Obtiene aquellos prestamos a los cuales no se les han enviado una notificacion.
        /// </summary>
        /// <param name="fechaActual"></param>
        /// <returns></returns>
        IList<Prestamo> ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTime fechaActual);
    }
}
