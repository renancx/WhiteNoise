using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class LeitoConfigurator : IEntityTypeConfiguration<Leito>
    {
        public void Configure(EntityTypeBuilder<Leito> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Tipo)
                   .IsRequired();

            builder.Property(l => l.Status)
                   .IsRequired();

            builder.HasOne(l => l.Departamento)
                   .WithMany(d => d.Leitos)
                   .HasForeignKey(l => l.DepartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}