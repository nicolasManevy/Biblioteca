using TallerBiblioteca.Aplication.DAL;

namespace TallerBiblioteca.Infrastructure.DAL.EntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Crear()
        {
            return new UnitOfWork();
        }
    }
}
