using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class InternacaoConfigurator : IEntityTypeConfiguration<Internacao>
    {
        public void Configure(EntityTypeBuilder<Internacao> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.DataEntrada)
                   .IsRequired();

            builder.Property(i => i.DataAlta);

            builder.Property(i => i.Motivo)
                   .IsRequired()
                   .HasMaxLength(500)
                   .IsUnicode(false);

            builder.Property(i => i.TipoSaida);

            builder.HasOne(i => i.Paciente)
                   .WithMany(p => p.Internacoes)
                   .HasForeignKey(i => i.PacienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Departamento)
                   .WithMany(d => d.Internacoes)
                   .HasForeignKey(i => i.DepartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
