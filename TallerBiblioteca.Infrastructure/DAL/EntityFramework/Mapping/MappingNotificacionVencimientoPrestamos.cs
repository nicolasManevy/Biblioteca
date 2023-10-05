using System.Data.Entity.ModelConfiguration;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework.Mapping
{
    internal class MappingNotificacionVencimientoPrestamos : EntityTypeConfiguration<NotificacionVencimientoPrestamo>
    {
        public void Configure()
        {
            HasKey(pNotificacion => pNotificacion.Id);

            HasRequired(pNotificacion => pNotificacion.Prestamo);
        }
    }
}
