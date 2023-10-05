using System;
using TallerBiblioteca.Domain.Common;
using TallerBiblioteca.Domain.Common.Excepciones;
using TallerBiblioteca.Domain.Common.IO.Usuarios;
using TallerBiblioteca.Domain.Seguridad;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Domain.Modelos
{
    public class Usuario : Entidad
    {
        public bool EsAdministrador { get; set; }
        public string NombreUsuario { get; set; }
        public string HashContraseña { get; set; }
        public string Mail { get; set; }
        public int Dni { get; set; }
        public int Puntaje { get; set; }

        public static Usuario Crear(CrearUsuarioDTO solicitud,
                                    IHashingManager hashingManager,
                                    IDateTimeProvider dateTimeProvider)
        {
            if (solicitud == null) throw new ArgumentNullException(nameof(solicitud));
            if (hashingManager == null) throw new ArgumentNullException(nameof(hashingManager));
            if (dateTimeProvider == null) throw new ArgumentNullException(nameof(dateTimeProvider));

            Usuario usuario = new Usuario();

            usuario.Dni = solicitud.Dni;
            usuario.EsAdministrador = solicitud.EsAdminitrador;
            usuario.Puntaje = 0;

            if (solicitud.NombreUsuario != null && solicitud.NombreUsuario.Length != 0)
            {
                usuario.NombreUsuario = solicitud.NombreUsuario;
            } else
            {
                throw new ArgumentException(nameof(solicitud.NombreUsuario));
            }

            if (solicitud.Mail != null && solicitud.Mail.Length != 0)
            {
                if (!ValidacionesDatos.EsMailValido(solicitud.Mail))
                {
                    throw new ExcepcionEmailInvalido();
                }
                usuario.Mail = solicitud.Mail;
            } else
            {
                throw new ArgumentException(nameof(solicitud.Mail));
            }

            if (solicitud.Password != null && solicitud.Password.Length != 0)
            {
                usuario.HashContraseña = hashingManager.Hash(solicitud.Password);
            } else
            {
                throw new ArgumentException(nameof(solicitud.Password));
            }

            return usuario;
        }

        public void Actualizar(ActualizarUsuarioDTO usuario, IHashingManager hashingManager)
        {
            if (usuario.Nombre != null && usuario.Nombre.Length != 0)
            {
                NombreUsuario = usuario.Nombre;
            }

            if (usuario.Mail != null && usuario.Mail.Length != 0)
            {
                if (!ValidacionesDatos.EsMailValido(usuario.Mail))
                {
                    throw new ExcepcionEmailInvalido();
                }

                Mail = usuario.Mail;
            }

            if (usuario.Password != null && usuario.Password.Length != 0)
            {
                HashContraseña = hashingManager.Hash(usuario.Password);
            }
        }

        /// <summary>
        /// Devuelve la cantidad de días que se puede extender el préstamo,
        //  en base al puntaje del usuario.
        /// </summary>
        public int MaximoDiasHabilesPrestamos()
        {
            int dias = Constantes.Prestamo.DiasBaseDePrestamo;

            if (Puntaje > 0)
            {
                dias += this.Puntaje / Constantes.Puntaje.PuntajeNecesarioParaExtenderElPrestamoUnDia;
                dias = Math.Min(dias, Constantes.Prestamo.DiasMaximoDePrestamo);
            }

            return dias;
        }

        public bool Loguear(string aVerificar, IHashingManager hashingManager)
        {
            return hashingManager.Verify(aVerificar, HashContraseña);
        }
    }
}
