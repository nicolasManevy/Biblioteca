using System.Data.Entity;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad
    {
        protected readonly DbSet<T> _set;

        public Repositorio(DbSet<T> set)
        {
            _set = set;
        }

        public void Agregar(T item)
        {
            _set.Add(item);
        }

        public void Eliminar(T item)
        {
            _set.Remove(item);
        }

        /// <inheritdoc/>
        public T Obtener(int id)
        {
            return _set.Find(id);
        }
    }
}
