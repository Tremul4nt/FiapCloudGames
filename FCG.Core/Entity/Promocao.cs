﻿namespace FCG.Core.Entity
{
    public class Promocao : EntityBase
    {
        public required int JogoId { get; set; }
        public required decimal ValorPromocao { get; set; }
        public required DateTime DataInicio { get; set; }
        public required DateTime DataFim { get; set; }
        public Jogo Jogo { get; set; }

    }
}
