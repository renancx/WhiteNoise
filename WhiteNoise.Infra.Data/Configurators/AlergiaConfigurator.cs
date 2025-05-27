using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class AlergiaConfigurator : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Tipo)
                   .IsRequired();

            builder.HasOne<Prontuario>()
                   .WithMany(p => p.Alergias)
                   .HasForeignKey("ProntuarioId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex("ProntuarioId");
        }
    }
}