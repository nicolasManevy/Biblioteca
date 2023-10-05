namespace TallerBiblioteca.Aplication.Common.IO.Edicion
{
    public class DTOEdicion
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public int AñoEdicion { get; set; }
        public int NumeroPaginas { get; set; }
        public string Portada { get; set; }
        public string Autores { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Publicacion { get; set; }
        public string DatosAdicionales { get; set; }
    }
}
