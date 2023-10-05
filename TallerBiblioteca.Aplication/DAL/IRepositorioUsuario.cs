using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.DAL
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        /// <summary>
        /// Obtiene un usuario por su nombre de usuario
        /// </summary>
        /// <param name="NombreUsuario">Nombre de usuario</param>
        /// <returns>Usuario o null si no existe</returns>
        Usuario ObtenerPorNombreDeUsuario(string NombreUsuario);

        /// <summary>
        /// Obtiene un usuario por su DNI
        /// </summary>
        /// <param name="Dni">DNI del usuario</param>
        /// <returns>Usuario o null si no existe</returns>
        Usuario ObtenerPorDNI(int Dni);


        /// <summary>
        /// Obtiene un usuario por su mail
        /// </summary>
        /// <param name="mail">mail del usuario</param>
        /// <returns>Usuario o null si no existe</returns>
        Usuario ObtenerPorMail(string mail);
    }
}
