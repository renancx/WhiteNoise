using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Identity;

namespace WhiteNoise.Infra.Data.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("IdentityUser");
            builder.Entity<IdentityRole>().ToTable("IdentityRole");
            builder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserToken");
        }
    }
}
