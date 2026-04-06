using ApiClaudeCode.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiClaudeCode.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Estoque)
            .IsRequired();

        builder.HasData(
            new Produto { Id = 1, Nome = "Teclado Mecânico", Preco = 349.90m, Estoque = 50 },
            new Produto { Id = 2, Nome = "Mouse Gamer",      Preco = 199.90m, Estoque = 75 },
            new Produto { Id = 3, Nome = "Monitor 24\"",     Preco = 1299.00m, Estoque = 20 }
        );
    }
}
