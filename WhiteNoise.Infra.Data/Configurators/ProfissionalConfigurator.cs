using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class ProfissionalConfigurator : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(80)");

            builder.Property(x => x.Cpf).IsRequired().HasColumnType("varchar(11)").HasMaxLength(11).IsFixedLength(true);

            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(100)");
        }
    }
}
