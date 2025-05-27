using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;

public class PacienteConfigurator : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(80)");

        builder.Property(x => x.Cpf).IsRequired().HasColumnType("varchar(11)").HasMaxLength(11).IsFixedLength(true);

        builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(100)");

        builder.Property(x => x.Motivo).HasColumnType("varchar(150)");

        builder.HasOne(p => p.Prontuario).WithMany().HasForeignKey(p => p.ProntuarioId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(p => p.Agendamento).WithMany().HasForeignKey(p => p.AgendamentoId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(p => p.Internacao).WithMany().HasForeignKey(p => p.InternacaoId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(p => p.EstadoClinico).WithMany().HasForeignKey(p => p.EstadoClinicoId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
    }
}
