using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace NHSDP_SPA.Auth.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = Constants.Roles.Student, NormalizedName = Constants.Roles.Student.ToUpper() },
                new IdentityRole { Name = Constants.Roles.Teacher, NormalizedName = Constants.Roles.Teacher.ToUpper() }
            );
        }
    }
}
