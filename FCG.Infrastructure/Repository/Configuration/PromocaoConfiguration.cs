using FCG.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configuration
{
    public class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("PROMOCAO").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnName("DATA_CRIACAO").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.JogoId).HasColumnName("ID_JOGO").HasColumnType("INT").IsRequired();
            builder.Property(p => p.ValorPromocao).HasColumnName("VALOR").HasColumnType("DECIMAL").IsRequired();
            builder.Property(p => p.DataInicio).HasColumnName("DATA_INICIO").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DataFim).HasColumnName("DATA_FIM").HasColumnType("DATETIME").IsRequired();

            builder.HasOne(p => p.Jogo).WithMany(c => c.Promocoes).HasPrincipalKey(u => u.Id);
        }
    }
}
