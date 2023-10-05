namespace TallerBiblioteca.Domain.Common.IO.Usuarios
{
    public class CrearUsuarioDTO
    {
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public int Dni { get; set; }

        public bool EsAdminitrador { get; set; }
    }
}
