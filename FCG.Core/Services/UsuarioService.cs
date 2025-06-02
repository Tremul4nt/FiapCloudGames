using FCG.Core.DTO;
using FCG.Core.Entity;
using FCG.Core.Repository;
using FCG.Core.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace FCG.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        public bool CriptografaSenha(string senha, Usuario usuario)
        {
            using var hmac = new HMACSHA512();
            usuario.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            usuario.PasswordSalt = hmac.Key;
            return true;
        }

        public bool ValidaSenha(Usuario usuario, string senha)
        {
            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != usuario.PasswordHash[x])
                    return false;
            }
            return true;
        }
    }
}
