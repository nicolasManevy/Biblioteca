using System.Data.Entity.ModelConfiguration;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping
{
    internal class MappingUsuario : EntityTypeConfiguration<Usuario>
    {
        public MappingUsuario()
        {
            HasKey(pUsuario => pUsuario.Id);

            Property(pUsuario => pUsuario.NombreUsuario)
                .HasMaxLength(20)
                .IsRequired();

            Property(pUsuario => pUsuario.Dni)
                .IsRequired();

            Property(pUsuario => pUsuario.HashContraseña)
                .HasMaxLength(150)
                .IsRequired();

            Property(pUsuario => pUsuario.Mail)
                .HasMaxLength(100)
                .IsRequired();

            Property(pUsuario => pUsuario.Puntaje)
                .IsRequired();
        }
    }
}
