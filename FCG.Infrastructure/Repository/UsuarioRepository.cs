using FCG.Core.Entity;
using FCG.Core.Repository;

namespace FCG.Infrastructure.Repository
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository

    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Usuario? GetByNome(string nome)
        {
            var result = _context.Set<Usuario>().FirstOrDefault(x => x.Nome == nome);
            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}
