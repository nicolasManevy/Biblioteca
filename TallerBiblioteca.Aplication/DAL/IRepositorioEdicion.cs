using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.DAL
{
    public interface IRepositorioEdicion : IRepositorio<Edicion>
    {
        ///
        /// <summary>
        /// Obtiene una edicion por su ISBN
        /// </summary>
        /// <param name="Isbn">ISBN de la edicion</param>
        /// <returns>Edicion o nulo si no se encuentra</returns>
        Edicion ObtenerPorISBN(string Isbn);
    }
}
