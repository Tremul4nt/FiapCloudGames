using FCG.Core.Entity;
using FCG.Core.Repository;

namespace FCG.Infrastructure.Repository
{
    public class JogoRepository : EFRepository<Jogo>, IJogoRepository
    {
        public JogoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
