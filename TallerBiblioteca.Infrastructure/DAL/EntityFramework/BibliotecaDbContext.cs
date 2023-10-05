using System.Data.Entity;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Edicion> Ediciones { get; set; }
        public DbSet<Ejemplar> Ejemplares { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NotificacionVencimientoPrestamo> NotificacionesVencimiento { get; set; }

        public BibliotecaDbContext() : base("ConexionBiblioteca") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edicion>().ToTable("Ediciones");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Ejemplar>().ToTable("Ejemplares");
            modelBuilder.Entity<NotificacionVencimientoPrestamo>().ToTable("NotificacionesVencimientoPrestamo");

            modelBuilder.Configurations.Add(new MappingEdicion());
            modelBuilder.Configurations.Add(new MappingEjemplar());
            modelBuilder.Configurations.Add(new MappingNotificacionVencimientoPrestamos());
            modelBuilder.Configurations.Add(new MappingPrestamo());
            modelBuilder.Configurations.Add(new MappingUsuario());
        }
    }
}
