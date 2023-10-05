using System.Threading.Tasks;
using TallerBiblioteca.Aplication.Common.IO.Edicion;

namespace TallerBiblioteca.Aplication.LibrosRemotos
{
    public interface IServicioEdicionRemota
    {
        Task<DTOEdicion> BuscarPorISBNAsync(string pISBN);
    }
}
