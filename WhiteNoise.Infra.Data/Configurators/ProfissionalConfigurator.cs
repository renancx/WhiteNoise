using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class ProfissionalConfigurator : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.DataNascimento)
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasMaxLength(100);

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(p => p.Cpf)
                   .HasMaxLength(11);

            builder.Property(p => p.Sexo)
                   .IsRequired();

            builder.HasIndex(p => p.Cpf)
                   .IsUnique();

            builder.HasOne(p => p.Departamento)
                   .WithMany()
                   .HasForeignKey(p => p.DepartamentoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Agendamentos)
                   .WithOne(a => a.Profissional)
                   .HasForeignKey(a => a.ProfissionalId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}