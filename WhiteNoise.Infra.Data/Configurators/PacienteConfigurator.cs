using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class PacienteConfigurator : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasOne(p => p.EstadoClinico)
                   .WithMany()
                   .HasForeignKey(p => p.EstadoClinicoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Internacoes)
                   .WithOne(i => i.Paciente)
                   .HasForeignKey(i => i.PacienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Agendamentos)
                   .WithOne(a => a.Paciente)
                   .HasForeignKey(a => a.PacienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.TipoPaciente)
                   .IsRequired();

            builder.Property(p => p.TipoSanguineo)
                   .IsRequired();

            builder.Property(p => p.EmInternacao)
                   .HasDefaultValue(false);
        }
    }
}