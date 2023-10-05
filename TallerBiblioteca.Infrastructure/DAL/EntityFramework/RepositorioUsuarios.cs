using System.Data.Entity;
using System.Linq;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class RepositorioUsuarios : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuarios(DbSet<Usuario> set)
            : base(set)
        {
        }

        public Usuario ObtenerPorNombreDeUsuario(string NombreUsuario)
        {
            return _set.Where(u => u.NombreUsuario == NombreUsuario).FirstOrDefault();
        }

        public Usuario ObtenerPorDNI(int dni)
        {
            return _set.Where(u => u.Dni == dni).FirstOrDefault();
        }

        public Usuario ObtenerPorMail(string mail)
        {
            return _set.Where(u => u.Mail == mail).FirstOrDefault();
        }
    }
}
