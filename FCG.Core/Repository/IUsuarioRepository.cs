using FCG.Core.Entity;

namespace FCG.Core.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? GetByNome(string nome);
    }
}
