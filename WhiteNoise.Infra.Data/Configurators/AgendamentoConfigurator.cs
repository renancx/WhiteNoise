using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class AgendamentoConfigurator : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.DataHora).IsRequired();
            builder.Property(a => a.Tipo).IsRequired();
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.Observacoes).HasMaxLength(500);

            builder.HasOne(a => a.Profissional)
                   .WithMany(p => p.Agendamentos)
                   .HasForeignKey(a => a.ProfissionalId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Paciente)
                   .WithMany(p => p.Agendamentos)
                   .HasForeignKey(a => a.PacienteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
