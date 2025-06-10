using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Seeds;

namespace WhiteNoise.Infra.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        #region DbSets
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<EstadoClinico> EstadoClinico { get; set; }
        public DbSet<Internacao> Internacao { get; set; }
        public DbSet<Leito> Leito { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(x => x.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            new EstadoClinicoSeed().Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}

//add-migration -c ApplicationDbContext -o C:\Users\renan.loewenstein\source\repos\WhiteNoise\WhiteNoise.Infra.Data\Migrations\ InitialMigration -v

//dotnet ef database update -p WhiteNoise.Infra.Data -s WhiteNoise -c ApplicationDbContext -v

//add-migration -c IdentityContext -o C:\Users\renan.loewenstein\source\repos\WhiteNoise\WhiteNoise.Infra.Data\Migrations\Identity ApplicationUserConfig -v

//dotnet ef database update -p WhiteNoise.Infra.Data -s WhiteNoise -c IdentityContext -v