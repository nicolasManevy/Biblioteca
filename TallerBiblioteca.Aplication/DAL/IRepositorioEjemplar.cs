using System.Collections.Generic;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.DAL
{
    public interface IRepositorioEjemplar : IRepositorio<Ejemplar>
    {
        List<Ejemplar> ObtenerPorISBN(string ISBN);
    }
}
