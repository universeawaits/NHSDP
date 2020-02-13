using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using NHSDP_SPA.Auth.Models;


namespace NHSDP_SPA.Auth
{
    public class IdentityContext : IdentityDbContext<Student>
    {
        public DbSet<Student> Students { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
    }
}
