using MapsterMapper;
using System.Collections.Generic;
using TallerBiblioteca.Aplication.Common.Excepciones.Ediciones;
using TallerBiblioteca.Aplication.Common.IO.Ejemplar;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Aplication
{
    public class FachadaEjemplar
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public FachadaEjemplar(
            IUnitOfWorkFactory unitOfWorkFactory,
            IDateTimeProvider dateTimeProvider,
            IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega un ejemplar.
        /// </summary>
        /// <param name="ejemplar">Datos del ejemplar a agregar.</param>
        /// <exception cref="ExcepcionEdicionNoExiste">Si no existe una edición con el ISBN indicado.</exception>
        public void AgregarEjemplar(AgregarEjemplarDTO ejemplar)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Edicion edicion = bUoW.RepositorioEdiciones.ObtenerPorISBN(ejemplar.ISBNEdicion);

                if (edicion == null)
                {
                    throw new ExcepcionEdicionNoExiste();
                }

                Ejemplar ejemplar1 = new Ejemplar
                {
                    Edicion = edicion,
                    FechaAlta = _dateTimeProvider.Now,
                };

                bUoW.RepositorioEjemplares.Agregar(ejemplar1);

                bUoW.Commit();
            }
        }

        /// <summary>
        /// Obtiene una lista de ejemplares de una edicion.
        /// </summary>
        /// <param name="isbn">ISBN de la edicion.</param>
        /// <returns>Lista de ejemplares con datos sobre si esta prestado.</returns>
        public List<DatosEjemplarDTO> ListarEjemplares(string isbn)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                List<Ejemplar> listaEjemplares = bUoW.RepositorioEjemplares.ObtenerPorISBN(isbn);
                List<DatosEjemplarDTO> prestamosEjemplares = new List<DatosEjemplarDTO>();
                foreach (var ejemplar in listaEjemplares)
                {
                    var prestamo = bUoW.RepositorioPrestamos
                                            .ObtenerSinDevolverPorCodigoEjemplarODefault(ejemplar.Id);

                    bool estaPrestado = prestamo != null;

                    var ejemplarPrestamo = _mapper.Map<DatosEjemplarDTO>(ejemplar);
                    ejemplarPrestamo.Prestado = estaPrestado;
                    ejemplarPrestamo.PrestadoA = estaPrestado ? $"dni: {prestamo.Solicitante.Dni}" : null;
                    prestamosEjemplares.Add(ejemplarPrestamo);
                }
                return prestamosEjemplares;
            };
        }

        /// <summary>
        /// Da de baja un ejemplar.
        /// </summary>
        /// <param name="pIdEjemplar">Id del ejemplar.</param>
        public void BajaEjemplar(int pIdEjemplar)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Ejemplar ejemplar = bUoW.RepositorioEjemplares.Obtener(pIdEjemplar);

                ejemplar.DarDeBaja(_dateTimeProvider);

                bUoW.Commit();
            }
        }

        /// <summary>
        /// Verifica si un ejemplar está prestado.
        /// </summary>
        /// <param name="pIdEjemplar">Id del ejemplar.</param>
        /// <returns>true si está prestado.</returns>
        private bool EstaPrestadoEjemplar(int pIdEjemplar)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                return bUoW.RepositorioPrestamos
                            .ObtenerSinDevolverPorCodigoEjemplarODefault(pIdEjemplar) != null;
            }
        }
    }
}
