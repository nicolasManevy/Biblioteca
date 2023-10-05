using Mapster;
using TallerBiblioteca.Aplication.Common.IO.Ejemplar;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.Common.Mapping
{
    internal class EjemplarMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Ejemplar, DatosEjemplarDTO>();
        }
    }
}
