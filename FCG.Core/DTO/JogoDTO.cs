using System.ComponentModel.DataAnnotations;

namespace FCG.Core.DTO
{
    public class JogoDTO
    {
        [Required(ErrorMessage = "O Nome do jogo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo do campo: 100 caracteres.")]
        public required string Nome { get; set; }
        
        [MaxLength(100, ErrorMessage = "Tamanho máximo do campo: 100 caracteres.")]
        public required string Categoria { get; set; }
        
        [Range(0,double.MaxValue,ErrorMessage ="Valor deve positivo")]
        public required decimal Valor { get; set; }
    }
}
