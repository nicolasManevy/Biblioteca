using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Aplication
{
    /// <summary>
    /// Esta asegura que las condiciones del sistema esten
    /// dadas para poder inicar correctamente su funcionamiento
    /// Condiciones:
    ///     - Que haya por lo menos un usuario administrador
    /// </summary>
    public class InicioSistema
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IHashingManager _hashingManager;

        public InicioSistema(
            IUnitOfWorkFactory unitOfWorkFactory,
            IDateTimeProvider dateTimeProvider,
            IHashingManager hashingManager)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            _dateTimeProvider = dateTimeProvider;
            _hashingManager = hashingManager;
        }

        public void Inicio()
        {
            CrearAdminSiNoHayUsuarios();
        }

        private void CrearAdminSiNoHayUsuarios()
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                // TODO: Hacer una mejor verificacion
                if (bUoW.RepositorioUsuarios.ObtenerPorDNI(0) == null)
                {
                    Usuario admin = Usuario.Crear(
                        new CrearUsuarioDTO
                        {
                            Dni = 0,
                            EsAdminitrador = true,
                            Mail = "email@cambiar.com",
                            NombreUsuario = "admin",
                            Password = "admin"
                        },
                        _hashingManager,
                        _dateTimeProvider);

                    bUoW.RepositorioUsuarios.Agregar(admin);
                }

                bUoW.Commit();
            }
        }
    }
}
