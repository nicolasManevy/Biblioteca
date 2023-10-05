using System.Text.RegularExpressions;

namespace TallerBiblioteca.Domain.Common
{
    public static class ValidacionesDatos
    {
        public static bool EsMailValido(string email)
        {
            // Expresión regular para validar la dirección de correo electrónico
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Comprobar si la dirección de correo electrónico coincide con el patrón
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
