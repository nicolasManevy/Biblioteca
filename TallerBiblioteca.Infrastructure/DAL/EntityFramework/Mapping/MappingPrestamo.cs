using System.Data.Entity.ModelConfiguration;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping
{
    internal class MappingPrestamo : EntityTypeConfiguration<Prestamo>
    {
        public MappingPrestamo()
        {
            HasKey(pPrestamo => pPrestamo.Id);

            Property(pPrestamo => pPrestamo.FechaPrestamo)
                .IsRequired();

            Property(pPrestamo => pPrestamo.FechaDevolucion);

            Property(pPrestamo => pPrestamo.FechaVencimiento)
                .IsRequired();

            HasRequired(pPrestamo => pPrestamo.Solicitante);

            HasRequired(pPrestamo => pPrestamo.Ejemplar);
        }

    }
}
