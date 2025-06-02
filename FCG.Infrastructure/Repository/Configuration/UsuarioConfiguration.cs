using FCG.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Repository.Configuration
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnName("DATA_CRIACAO").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Email).HasColumnName("EMAIL").HasColumnType("VARCHAR(100)").IsRequired();            
            builder.Property(p => p.Admin).HasColumnName("ADMIN").HasColumnType("INT").IsRequired();
        }
    }
}
