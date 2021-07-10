using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.Infra.Mappings
{
    public class ChurrascoMapping : IEntityTypeConfiguration<Churrasco>
    {
        public void Configure(EntityTypeBuilder<Churrasco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataHora)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Observacao)
                .HasColumnType("varchar(300)");

            builder.Property(c => c.ValorComBebida)
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.ValorSemBebida)
                .HasColumnType("decimal(5,2)");

            builder.HasMany(c => c.Participantes)
                .WithOne(p => p.Churrasco)
                .HasForeignKey(c => c.ChurrascoId);

            builder.ToTable("Churrasco");
        }
    }
}
