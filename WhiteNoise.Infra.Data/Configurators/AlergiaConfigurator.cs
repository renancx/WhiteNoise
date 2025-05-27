using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Configurators
{
    public class AlergiaConfigurator : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
        }
    }
}