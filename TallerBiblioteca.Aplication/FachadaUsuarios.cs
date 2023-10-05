using MapsterMapper;
using TallerBiblioteca.Aplication.Common.Excepciones;
using TallerBiblioteca.Aplication.Common.IO.Usuarios;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Domain.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Aplication
{
    public class FachadaUsuarios
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IHashingManager _hashingManager;
        private readonly IMapper _mapper;
        private readonly IDateTimeProvider _dateTimeProvider;

        public FachadaUsuarios(
            IUnitOfWorkFactory unitOfWorkFactory,
            IHashingManager hashingManager,
            IDateTimeProvider dateTimeProvider,
            IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _hashingManager = hashingManager;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Inicia sesion de un usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <returns>true si el usuario existe y la contraseña es correcta.</returns>
        public bool LoguearUsuario(string nombreUsuario, string password)
        {
            bool contraCorrecta = false;

            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);

                if (usuario == null)
                {
                    return false;
                }

                contraCorrecta = usuario.Loguear(password, _hashingManager);

                bUoW.Commit();
            }

            return contraCorrecta;
        }

        /// <summary>
        /// Modifica los datos de un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario a modificar.</param>
        /// <param name="solicitud">Datos a modificar. Dejar en null los campos que no se quieran modificar.</param>
        /// <exception cref="ExcepcionUsuarioNoExiste">Si el usuario no existe.</exception>
        /// <exception cref="ExcepcionUsuarioConNombreDeUsuarioYaExiste">Si el nombre de usuario ya existe.</exception>
        /// <exception cref="ExcepcionUsuarioConMailYaExiste">Si el mail ya existe.</exception>
        public void ModificarDatosUsuario(int dni, ActualizarUsuarioDTO solicitud)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);

                if (usuario == null)
                {
                    throw new ExcepcionUsuarioNoExiste();
                }

                if (solicitud.Nombre != null
                    && solicitud.Nombre != usuario.NombreUsuario
                    && bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(solicitud.Nombre) != null)
                {
                    throw new ExcepcionUsuarioConNombreDeUsuarioYaExiste();
                }

                if (solicitud.Mail != null
                    && solicitud.Mail != usuario.Mail
                    && bUoW.RepositorioUsuarios.ObtenerPorMail(solicitud.Mail) != null)
                {
                    throw new ExcepcionUsuarioConMailYaExiste();
                }

                usuario.Actualizar(solicitud, _hashingManager);

                bUoW.Commit();
            }
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Usuario o null si no existe.</returns>
        public DatosUsuarioDTO ObtenerUsuario(string nombreUsuario)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Usuario usuarioObtenido = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);

                if (usuarioObtenido == null)
                {
                    return null;
                }

                return _mapper.Map<DatosUsuarioDTO>(usuarioObtenido);
            }
        }

        /// <summary>
        /// Obtiene un usuario por su dni.
        /// </summary>
        /// <param name="pDni">DNI del usuario.</param>
        /// <returns>Usuario o null si no existe.</returns>
        public DatosUsuarioDTO ObtenerUsuario(int pDni)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Usuario usuarioObtenido = bUoW.RepositorioUsuarios.ObtenerPorDNI(pDni);

                if (usuarioObtenido == null)
                {
                    return null;
                }

                return _mapper.Map<DatosUsuarioDTO>(usuarioObtenido);
            }
        }

        /// <summary>
        /// Verifica si un usuario es administrador.
        /// </summary>
        /// <remark>Se utiliza para verificar si un usuario puede realizar ciertas acciones.</remark>
        /// <param name="nombreUsuario">Nombre de usuario del usuario a verificar.</param>
        /// <returns>true si el usuario es administrador</returns>
        public bool EsUsuarioAdmin(string nombreUsuario)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                var usuario = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);
                return usuario.EsAdministrador;
            }
        }

        /// <summary>
        /// Da de baja un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario a dar de baja.</param>
        public void BajaUsuario(int dni)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);
                bUoW.RepositorioUsuarios.Eliminar(usuario);
                bUoW.Commit();
            }
        }

        /// <summary>
        /// Agrega un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con los datos del usuario a agregar.</param>
        /// <param name="esAdmin">Indica si el usuario a agregar es administrador.</param>
        /// <exception cref="ExcepcionUsuarioConDniYaExiste">Si ya existe un usuario con el DNI indicado.</exception>
        /// <exception cref="ExcepcionUsuarioConNombreDeUsuarioYaExiste">Si ya existe un usuario con el nombre de usuario indicado.</exception>
        /// <exception cref="ExcepcionUsuarioConMailYaExiste">Si ya existe un usuario con el mail indicado.</exception>
        public void AgregarUsuario(CrearUsuarioDTO solicitud, bool esAdmin)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.Crear())
            {
                if (bUoW.RepositorioUsuarios.ObtenerPorDNI(solicitud.Dni) != null)
                {
                    throw new ExcepcionUsuarioConDniYaExiste();
                }

                if (bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(solicitud.NombreUsuario) != null)
                {
                    throw new ExcepcionUsuarioConNombreDeUsuarioYaExiste();
                }

                if (bUoW.RepositorioUsuarios.ObtenerPorMail(solicitud.Mail) != null)
                {
                    throw new ExcepcionUsuarioConMailYaExiste();
                }

                var usuario1 = Usuario.Crear(solicitud, _hashingManager, _dateTimeProvider);

                bUoW.RepositorioUsuarios.Agregar(usuario1);

                bUoW.Commit();
            }
        }
    }
}
