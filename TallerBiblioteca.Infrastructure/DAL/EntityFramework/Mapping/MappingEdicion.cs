using System.Data.Entity.ModelConfiguration;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping
{
    internal class MappingEdicion : EntityTypeConfiguration<Edicion>
    {
        public MappingEdicion()
        {
            HasKey(pEdicion => pEdicion.Id);

            Property(pEdicion => pEdicion.Isbn)
                .IsRequired();

            Property(pEdicion => pEdicion.NumeroPaginas)
                .IsRequired();
        }
    }
}