namespace FCG.Core.Entity
{
    public class Usuario : EntityBase
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required bool Admin { get; set; }
        public byte [] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
        public List<Biblioteca> Bibliotecas { get; set; } 
    }
}
