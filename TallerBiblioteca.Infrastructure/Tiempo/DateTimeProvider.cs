using System;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Infrastructure.Tiempo
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
