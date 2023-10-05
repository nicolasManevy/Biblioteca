using MapsterMapper;
using TallerBiblioteca.Aplication.Common.Excepciones.Ediciones;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication
{
    public class FachadaEdicion
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMapper _mapper;

        public FachadaEdicion(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca una edicion por ISBN.
        /// </summary>
        /// <param name="ISBN">ISBN de la edicion.</param>
        /// <returns>Edicion o null si no se encuentra.</returns>
        public DTOEdicion BuscarEdicion(string ISBN)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Edicion encontrado = bUoW.RepositorioEdiciones.ObtenerPorISBN(ISBN);

                if (encontrado == null)
                {
                    return null;
                }

                return _mapper.Map<DTOEdicion>(encontrado);
            };
        }

        /// <summary>
        /// Agrega una edicion.
        /// </summary>
        /// <param name="pEdicion">Edicion a agregar.</param>
        public void AgregarEdicion(DTOEdicion pEdicion)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                if (bUoW.RepositorioEdiciones.ObtenerPorISBN(pEdicion.Isbn) != null)
                {
                    throw new ExcepcionEdicionYaExiste();
                }

                Edicion edicion = _mapper.Map<Edicion>(pEdicion);

                bUoW.RepositorioEdiciones.Agregar(edicion);

                bUoW.Commit();
            }
        }

        /// <summary>
        /// Modifica una edicion.
        /// </summary>
        /// <param name="pEdicion">Datos de la edicion.</param>
        /// <exception cref="ExcepcionEdicionNoExiste">Si la edicion no existe.</exception>
        public void ModificarEdicion(DTOEdicion pEdicion)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Edicion edicion = bUoW.RepositorioEdiciones.ObtenerPorISBN(pEdicion.Isbn);

                if (edicion == null)
                {
                    throw new ExcepcionEdicionNoExiste();
                }

                edicion.AñoEdicion = pEdicion.AñoEdicion;
                edicion.NumeroPaginas = pEdicion.NumeroPaginas;
                edicion.Portada = pEdicion.Portada ?? edicion.Portada;
                edicion.Titulo = pEdicion.Titulo ?? edicion.Titulo;
                edicion.Autores = pEdicion.Autores ?? edicion.Autores;
                edicion.Descripcion = pEdicion.Descripcion ?? edicion.Descripcion;
                edicion.Publicacion = pEdicion.Publicacion ?? edicion.Publicacion;
                edicion.DatosAdicionales = pEdicion.DatosAdicionales ?? edicion.DatosAdicionales;

                bUoW.Commit();
            }
        }
    }
}
