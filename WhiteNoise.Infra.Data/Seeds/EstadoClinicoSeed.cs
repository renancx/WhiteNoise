using System;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Seeds
{
    public class EstadoClinicoSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoClinico>().HasData(
                new EstadoClinico { Id = Guid.Parse("a4a4a4a4-0000-0000-0000-000000000001"), Descricao = "Estável" },
                new EstadoClinico { Id = Guid.Parse("a4a4a4a4-0000-0000-0000-000000000002"), Descricao = "Observação" },
                new EstadoClinico { Id = Guid.Parse("a4a4a4a4-0000-0000-0000-000000000003"), Descricao = "Grave" },
                new EstadoClinico { Id = Guid.Parse("a4a4a4a4-0000-0000-0000-000000000004"), Descricao = "Crítico" }
            );
        }
    }
}
