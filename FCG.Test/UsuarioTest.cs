using FCG.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace FCG.Test
{
    public class UsuarioTest
    {
        [Theory]
        [InlineData("", "teste@teste.com", "!23A5678")] 
        [InlineData("Teste nome com tamanho máximo acima do permitido.....................................................", "teste@teste.com", "!23A5678")] 
        [InlineData("nome", "", "!23A5678")] 
        [InlineData("nome", "testeEmailIncorreto", "!23A5678")] 
        [InlineData("nome", "teste@teste.com", "!23A567")] 
        [InlineData("nome", "teste@teste.com", "12345678")] 
        public void UsuarioEhInvalido(string nome, string email, string senha )
        {
            var usuario = new UsuarioDTO
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Admin = true
            };

            var result = Validator.TryValidateObject(usuario, new ValidationContext(usuario, null, null), null, true);
            Assert.True(!result);

        }
    }
}