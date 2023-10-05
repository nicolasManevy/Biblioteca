using System;
using System.Collections.Generic;
using System.Linq;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class RepositorioNotificacionVencimientoPrestamo : Repositorio<NotificacionVencimientoPrestamo>, IRepositorioNotificacionVencimientoPrestamo
    {
        private readonly BibliotecaDbContext _dBContext;

        public RepositorioNotificacionVencimientoPrestamo(BibliotecaDbContext pDbContext)
            : base(pDbContext.NotificacionesVencimiento)
        {
            _dBContext = pDbContext;
        }

        public IList<Prestamo> ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(DateTime fechaActual)
        {
            DateTime limite = fechaActual.AddDays(2);

            // Select * from prestamos join vencimientoNotificacion on (idPrestamos = idNotVencimiento.Prestamo)
            // where prestamos.fechaVencimiento < hoy - 2 and 

            return (from p in _dBContext.Prestamos
                    join nv in _dBContext.NotificacionesVencimiento
                                        on p.Id equals nv.Prestamo.Id
                                        into tmp
                    from nv in tmp.DefaultIfEmpty() // left join

                    where p.FechaVencimiento <= limite && nv == null
                    select p).ToList();
        }
    }
}
