using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class EstadoClinicoConfigurator : IEntityTypeConfiguration<EstadoClinico>
    {
        public void Configure(EntityTypeBuilder<EstadoClinico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("varchar(30)").IsRequired();

        }
    }
}