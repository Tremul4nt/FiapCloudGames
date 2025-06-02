using FCG.Core.Entity;
using FCG.Core.Services;
using FCG.Core.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace FCG.Test
{
    public class UsuarioServiceTest
    {
        [Fact]
        public void CriptografaSenhaComSucesso()
        {
            //Arrange
            var senha = "1234";
            Usuario usuario = new Usuario
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Admin = true                
            };

            //Act
            IUsuarioService usuarioService = new UsuarioService();

            //Assert
            bool result = usuarioService.CriptografaSenha(senha, usuario);
            Assert.True(result);

        }

        [Fact]
        public void DescriptografaSenhaComSucesso()
        {
            //Arrange
            var senha = "Passw0r#Admin";
            Usuario usuario = new Usuario
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Admin = true
            };

            using var hmac = new HMACSHA512();
            usuario.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            usuario.PasswordSalt = hmac.Key;

            //Act
            IUsuarioService usuarioService = new UsuarioService();
            bool result = usuarioService.ValidaSenha(usuario, "Passw0r#Admin");
            Assert.True(result);
        }

        [Fact]
        public void DescriptografaSenhaComErro()
        {
            //Arrange
            var senha = "Passw0r#Admin";
            Usuario usuario = new Usuario
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Admin = true
            };

            using var hmac = new HMACSHA512();
            usuario.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            usuario.PasswordSalt = hmac.Key;

            //Act
            IUsuarioService usuarioService = new UsuarioService();
            bool result = usuarioService.ValidaSenha(usuario, "Passw0r#Admin_");
            Assert.False(result);
        }

    }
}
