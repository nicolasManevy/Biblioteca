namespace TallerBiblioteca.Domain.Modelos
{
    public class Edicion : Entidad
    {
        /// <summary>
        /// El número ISBN del libro.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// El año de edición del libro.
        /// </summary>
        public int AñoEdicion { get; set; }

        /// <summary>
        /// El número de páginas del libro.
        /// </summary>
        public int NumeroPaginas { get; set; }

        /// <summary>
        /// La ruta de la portada del libro.
        /// </summary>
        public string Portada { get; set; }

        /// <summary>
        /// El título del libro.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// La descripción del libro.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// El nombre de los autores del libro.
        /// </summary>
        public string Autores { get; set; }

        /// <summary>
        /// Datos adicionales de la publicación, como editorial y fecha de publicación.
        /// </summary>
        public string Publicacion { get; set; }

        /// <summary>
        /// Datos adicionales relacionados con el libro.
        /// </summary>
        public string DatosAdicionales { get; set; }
    }
}
