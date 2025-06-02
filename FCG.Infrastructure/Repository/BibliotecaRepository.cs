using FCG.Core.Entity;
using FCG.Core.Repository;

namespace FCG.Infrastructure.Repository
{
    public class BibliotecaRepository : EFRepository<Biblioteca>, IBibliotecaRepository
    {
        public BibliotecaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
