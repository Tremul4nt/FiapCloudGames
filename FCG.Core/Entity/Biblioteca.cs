namespace FCG.Core.Entity
{
    public class Biblioteca: EntityBase
    {
        public int UsuarioId { get; set; }
        public int JogoId { get; set; }
        public Usuario Usuario { get; set; }
        public Jogo  Jogo { get; set; }
    }
}
