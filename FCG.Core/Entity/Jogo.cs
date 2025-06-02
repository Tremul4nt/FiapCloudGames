namespace FCG.Core.Entity
{
    public class Jogo: EntityBase
    {
        public required string Nome { get; set; }
        public required string Categoria { get; set; }
        public required decimal ValorCompra { get; set; }
        public List<Biblioteca> Bibliotecas { get; set; } = [];
        public List<Promocao> Promocoes { get; set; } = [];
    }
}
