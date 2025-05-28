using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class ProntuarioConfigurator : IEntityTypeConfiguration<Prontuario>
    {
        public void Configure(EntityTypeBuilder<Prontuario> builder)
        {
            builder.Property(p => p.DataCriacao)
                   .IsRequired();

            builder.Property(p => p.Observacao)
                   .HasMaxLength(500);

            builder.HasOne(p => p.Paciente)
               .WithMany(d => d.Prontuarios)
               .HasForeignKey(p => p.PacienteId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}