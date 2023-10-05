namespace TallerBiblioteca.Aplication.DAL
{
    public interface IRepositorio<T>
    {
        void Agregar(T item);

        /// <summary>
        /// Obtiene el elemento por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El elemento o null</returns>
        T Obtener(int id);

        void Eliminar(T item);
    }
}
