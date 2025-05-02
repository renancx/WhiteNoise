using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Infra.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<EstadoClinico> EstadoClinico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(x => x.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
