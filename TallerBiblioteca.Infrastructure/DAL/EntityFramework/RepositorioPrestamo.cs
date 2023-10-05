using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class RepositorioPrestamo :
        Repositorio<Prestamo>,
        IRepositorioPrestamo
    {
        public RepositorioPrestamo(DbSet<Prestamo> set) : base(set)
        {
        }

        public List<Prestamo> ObtenerProximoAVencer(DateTime limite)
        {
            return _set
                    .Where(u => (u.FechaVencimiento <= limite && u.FechaDevolucion == null))
                    .ToList();
        }

        public List<Prestamo> ObtenerPrestamosPorDNIEntreFechas(int dni, DateTime start, DateTime end)
        {
            return _set
                    .Include(p => p.Ejemplar) // precargar
                    .Include(p => p.Solicitante) // precargar
                    .Where(u => (u.Solicitante.Dni == dni && u.FechaPrestamo >= start && u.FechaPrestamo <= end))
                    .ToList();
        }

        public Prestamo ObtenerSinDevolverPorCodigoEjemplarODefault(int idEjemplar)
        {
            return _set
                    .Where(u => (u.Ejemplar.Id == idEjemplar && u.FechaDevolucion == null))
                    .FirstOrDefault();
        }

        public List<Prestamo> ObtenerPorCodigoEjemplar(int idEjemplar)
        {
            return _set
                    .Where(u => (u.Ejemplar.Id == idEjemplar))
                    .ToList();
        }
    }
}
