using System;
using System.Collections.Generic;
using System.Linq;
using TallerBiblioteca.Aplication.Common.Excepciones;
using TallerBiblioteca.Aplication.Common.Excepciones.Ejemplar;
using TallerBiblioteca.Aplication.Common.Excepciones.Prestamo;
using TallerBiblioteca.Aplication.Common.IO.Prestamo;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Aplication
{
    public class FachadaPrestamo
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDateTimeProvider _dateTimeProvider;

        public FachadaPrestamo(IUnitOfWorkFactory unitOfWorkFactory, IDateTimeProvider dateTimeProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Presta un ejemplar.
        /// </summary>
        /// <param name="pDni">DNI del usuario que pide el ejemplar.</param>
        /// <param name="pIdEjemplar">Id del ejemplar.</param>
        /// <returns>Fecha de vencimiento del préstamo.</returns>
        /// <exception cref="ExcepcionEjemplarYaPrestado">Si el ejemplar ya está prestado.</exception>
        /// <exception cref="ExcepcionEjemplarNoExiste">Si el ejemplar no existe.</exception>
        /// <exception cref="ExcepcionUsuarioNoExiste">Si el usuario no existe.</exception>
        /// <exception cref="EjemplarEstaDadoDeBaja">Si el ejemplar esta dado de baja.</exception>
        public DateTime PrestarEjemplar(int pDni, int pIdEjemplar)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                bool estaPrestado = bUoW.RepositorioPrestamos
                                .ObtenerSinDevolverPorCodigoEjemplarODefault(pIdEjemplar) != null;

                if (estaPrestado)
                {
                    throw new ExcepcionEjemplarYaPrestado();
                }

                Ejemplar ejemplar = bUoW.RepositorioEjemplares.Obtener(pIdEjemplar);

                if (ejemplar == null)
                {
                    throw new ExcepcionEjemplarNoExiste();
                }

                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(pDni);

                if (usuario == null)
                {
                    throw new ExcepcionUsuarioNoExiste();
                }

                var prestamo = Prestamo.Prestar(ejemplar,
                                                usuario,
                                                _dateTimeProvider);

                bUoW.RepositorioPrestamos.Agregar(prestamo);

                bUoW.Commit();

                return prestamo.FechaVencimiento;
            }
        }

        /// <summary>
        /// Devuelve un ejemplar con estado.
        /// </summary>
        /// <param name="pIdEjemplar">Id del ejemplar.</param>
        /// <param name="buenEstado">true si el ejemplar está en buen estado.</param>
        /// <exception cref="ExcepcionEjemplarNoEstaPrestado">Si el ejemplar no está prestado.</exception>
        public void DevolverEjemplar(int pIdEjemplar, bool buenEstado)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Prestamo prestamo = bUoW.RepositorioPrestamos
                                            .ObtenerPorCodigoEjemplar(pIdEjemplar)
                                            .Where(u => u.FechaDevolucion == null)
                                            .FirstOrDefault();

                if (prestamo == null)
                {
                    throw new ExcepcionEjemplarNoEstaPrestado();
                }

                Usuario usuario = prestamo.Solicitante;

                prestamo.Devolver(buenEstado, _dateTimeProvider);

                bUoW.Commit();
            }
        }


        /// <summary>
        /// Obtiene una lista de prestamos entre dos fechas para un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario.</param>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaFin">Fecha de fin.</param>
        /// <returns>Lista de prestamos entre dos fechas para un usuario.</returns>
        public List<DTOPrestamoConUsuarioYEjemplar> PrestamosEntreFechas(int dni, DateTime fechaInicio, DateTime fechaFin)
        {
            // Setea la fecha fin a las 23:59:59
            fechaFin = fechaFin.AddHours(23 - fechaFin.Hour)
                                .AddMinutes(59 - fechaFin.Minute)
                                .AddSeconds(59 - fechaFin.Second);

            // Setea la fecha inicio a las 00:00:00
            fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day);

            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                var listaPrestamosEntreFechas = bUoW.RepositorioPrestamos.ObtenerPrestamosPorDNIEntreFechas(dni, fechaInicio, fechaFin);
                // Todo: Usar mapper
                return listaPrestamosEntreFechas.Select(p => new DTOPrestamoConUsuarioYEjemplar
                {
                    Id = p.Id,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaVencimiento = p.FechaVencimiento,
                    FechaDevolucion = p.FechaDevolucion,
                    Nombre = p.Solicitante.NombreUsuario,
                    IdEjemplar = p.Ejemplar.Id
                }).ToList();
            }
        }

        /// <summary>
        /// Obtiene una lista de prestamos proximos a vencer.
        /// </summary>
        /// <returns>Lista de prestamos proximos a vencer.</returns>
        public List<DTOPrestamo> PrestamosProximosAVencer()
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                var sig7Dias = DateTime.Today.AddDays(7);
                var listaPrestamosProxAVencer = bUoW.RepositorioPrestamos.ObtenerProximoAVencer(sig7Dias);
                return listaPrestamosProxAVencer.Select(p => new DTOPrestamo { SolicitanteDNI = p.Solicitante.Dni, Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento }).ToList();
            }
        }
    }
}
