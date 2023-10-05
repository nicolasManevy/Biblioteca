using System.Data.Entity.ModelConfiguration;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping
{
    internal class MappingEjemplar : EntityTypeConfiguration<Ejemplar>
    {
        public MappingEjemplar()
        {
            HasKey(pEjemplar => pEjemplar.Id);

            Property(pEjemplar => pEjemplar.CodigoInventario)
                .HasMaxLength(100);

            HasIndex(pEjemplar => pEjemplar.CodigoInventario);
            // No se puede forzar .IsUnique() ya que puede ser null

            Property(pEjemplar => pEjemplar.FechaAlta)
                 .IsRequired();

            HasRequired(pEjemplar => pEjemplar.Edicion);
        }

    }
}
