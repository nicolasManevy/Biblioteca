namespace TallerBiblioteca.Domain.Seguridad
{
    public interface IHashingManager
    {
        string Hash(string password, int iterations = 10000);
        bool Verify(string password, string hashedPassword);
        bool IsHashSupported(string hashString);
    }
}
