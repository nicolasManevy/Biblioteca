using TallerBiblioteca.Aplication.DAL;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BibliotecaDbContext _dbContext;
        private bool _disposed;

        public IRepositorioPrestamo RepositorioPrestamos { get; }

        public IRepositorioUsuario RepositorioUsuarios { get; }

        public IRepositorioEdicion RepositorioEdiciones { get; }

        public IRepositorioEjemplar RepositorioEjemplares { get; }

        public IRepositorioNotificacionVencimientoPrestamo RepositorioNotificacionVencimientoPrestamo { get; }

        public UnitOfWork()
        {
            _dbContext = new BibliotecaDbContext();

            RepositorioPrestamos = new RepositorioPrestamo(_dbContext.Prestamos);
            RepositorioUsuarios = new RepositorioUsuarios(_dbContext.Usuarios);
            RepositorioEdiciones = new RepositorioEdiciones(_dbContext.Ediciones);
            RepositorioEjemplares = new RepositorioEjemplares(_dbContext.Ejemplares);
            RepositorioNotificacionVencimientoPrestamo = new RepositorioNotificacionVencimientoPrestamo(_dbContext);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Commit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._dbContext.Dispose();
                }

                this._disposed = true;
            }
        }
    }
}
