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
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(i => i.TipoSaida);

            builder.Property(i => i.Ativa);

            builder.HasOne(i => i.Paciente)
                   .WithMany(p => p.Internacoes)
                   .HasForeignKey(i => i.PacienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Leito)
              .WithOne()
              .HasForeignKey<Internacao>(i => i.LeitoId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Prontuario)
              .WithOne()
              .HasForeignKey<Internacao>(i => i.ProntuarioId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
