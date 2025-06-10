using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class ProfissionalConfigurator : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.Property(p => p.RegistroProfissional)
                   .HasMaxLength(50);

            builder.HasOne(p => p.Departamento)
                   .WithMany(a => a.Profissionais)
                   .HasForeignKey(p => p.DepartamentoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Agendamentos)
                   .WithOne(a => a.Profissional)
                   .HasForeignKey(a => a.ProfissionalId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}