using FCG.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configuration
{
    internal class BibliotecaConfiguration : IEntityTypeConfiguration<Biblioteca>
    {
        public void Configure(EntityTypeBuilder<Biblioteca> builder)
        {
            builder.ToTable("BIBLIOTECA").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnName("DATA_CRIACAO").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.UsuarioId).HasColumnName("ID_USUARIO").HasColumnType("INT").IsRequired();
            builder.Property(p => p.JogoId).HasColumnName("ID_JOGO").HasColumnType("INT").IsRequired();

            builder.HasOne(p => p.Usuario).WithMany(c => c.Bibliotecas).HasPrincipalKey(u => u.Id);
            builder.HasOne(p => p.Jogo).WithMany(c => c.Bibliotecas).HasPrincipalKey(u => u.Id);
        }
    }
}
