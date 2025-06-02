using FCG.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configuration
{
    internal class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("JOGO").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnName("DATA_CRIACAO").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Categoria).HasColumnName("CATEGORIA").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.ValorCompra).HasColumnName("VALOR").HasColumnType("DECIMAL").IsRequired();
        }
    }
}
