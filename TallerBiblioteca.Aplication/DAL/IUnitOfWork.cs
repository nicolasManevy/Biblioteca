using System;

namespace TallerBiblioteca.Aplication.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioEjemplar RepositorioEjemplares { get; }

        IRepositorioPrestamo RepositorioPrestamos { get; }

        IRepositorioUsuario RepositorioUsuarios { get; }

        IRepositorioEdicion RepositorioEdiciones { get; }

        IRepositorioNotificacionVencimientoPrestamo RepositorioNotificacionVencimientoPrestamo { get; }

        void Commit();
    }
}
