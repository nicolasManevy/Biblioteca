using System;

namespace TallerBiblioteca.Domain.Tiempo
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
