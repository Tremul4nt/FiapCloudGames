using System.ComponentModel.DataAnnotations;

namespace FCG.Core.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O Nome do usuário é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo do campo: 100 caracteres.")]
        public required string Nome { get; set; }
        
        [Required(ErrorMessage = "O E-mail do usuário é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo do campo: 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Formado de email inválido.")]
        public required string Email { get; set; }

        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[^\w\s]).{8,}$", ErrorMessage = "Senha inválida. Deve conter números, letras e caracteres especiais e no mínimo oito caracteres.")]
        public required string Senha { get; set; }
        public required bool Admin { get; set; }
    }
}
