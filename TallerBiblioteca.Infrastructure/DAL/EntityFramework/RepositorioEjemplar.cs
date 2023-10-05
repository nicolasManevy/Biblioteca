using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class RepositorioEjemplares : Repositorio<Ejemplar>, IRepositorioEjemplar
    {
        public RepositorioEjemplares(DbSet<Ejemplar> set)
            : base(set)
        {

        }

        public List<Ejemplar> ObtenerPorISBN(string ISBN)
        {
            return _set.Where(u => u.Edicion.Isbn == ISBN).ToList();
        }
    }
}
