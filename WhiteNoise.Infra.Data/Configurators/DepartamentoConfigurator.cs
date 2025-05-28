using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class DepartamentoConfigurator : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Descricao)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasMany(d => d.Leitos)
                   .WithOne(l => l.Departamento)
                   .HasForeignKey(l => l.DepartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Profissionais)
                   .WithOne(l => l.Departamento)
                   .HasForeignKey(l => l.DepartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
