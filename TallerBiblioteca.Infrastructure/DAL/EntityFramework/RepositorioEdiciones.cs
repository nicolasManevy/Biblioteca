using System.Data.Entity;
using System.Linq;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class RepositorioEdiciones : Repositorio<Edicion>, IRepositorioEdicion
    {
        public RepositorioEdiciones(DbSet<Edicion> set) : base(set)
        {
        }

        public Edicion ObtenerPorISBN(string Isbn)
        {
            return _set.Where(u => u.Isbn == Isbn).FirstOrDefault();
        }
    }
}
