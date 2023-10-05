using Mapster;
using TallerBiblioteca.Aplication.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.Common.Mapping
{
    internal class UsuarioMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Usuario, DatosUsuarioDTO>();
        }
    }
}
