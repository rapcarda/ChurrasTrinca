using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.Infra.Mappings
{
    public class ParticipanteMapping : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.ToTable("Participante");
        }
    }
}
