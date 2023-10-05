using TallerBiblioteca.Domain.Modelos;

namespace TallerBiblioteca.Aplication.Servicios.Notificacion
{
    public interface INotificador
    {
        bool Enviar(string titulo, string cuerpo, Usuario usuario);
    }
}
