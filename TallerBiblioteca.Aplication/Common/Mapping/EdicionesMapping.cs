using Mapster;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.Common.Mapping
{
    internal class EdicionesMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Desde edicion a DTO
            config.NewConfig<Edicion, DTOEdicion>();

            // Desde DTO a Edicion
            config.NewConfig<DTOEdicion, Edicion>();
        }
    }
}
