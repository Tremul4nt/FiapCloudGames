using FCG.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace FCG.Test
{
    public class JogoTest
    {
        [Theory]
        [InlineData("", "categoria", 1.00)]
        [InlineData("Teste nome com tamanho máximo acima do permitido.....................................................", "categoria", 1.00)]
        [InlineData("nome jogo", "Teste categoria com tamanho máximo acima do permitido................................................", 1.00)]
        [InlineData("nome jogo", "categoria", -1)]
        public void UsuarioEhInvalido(string nome, string categoria, decimal valor)
        {
            var jogo = new JogoDTO
            {
                Nome = nome,
                Categoria = categoria,
                Valor = valor                
            };

            var result = Validator.TryValidateObject(jogo, new ValidationContext(jogo, null, null), null, true);
            Assert.True(!result);

        }    
    }
}
