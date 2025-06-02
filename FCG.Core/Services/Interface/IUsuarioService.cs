using FCG.Core.Entity;

namespace FCG.Core.Services.Interface
{
    public interface IUsuarioService
    {        
        bool CriptografaSenha(string senha, Usuario usuario );
        bool ValidaSenha(Usuario usuario, string senha);
    }
}
