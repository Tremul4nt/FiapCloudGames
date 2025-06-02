using System.ComponentModel.DataAnnotations;

namespace FCG.Core.DTO
{
    public class PromocaoDTO
    {
        public required int JogoId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Valor deve positivo")]
        public required decimal ValorPromocao { get; set; }

        public required DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
