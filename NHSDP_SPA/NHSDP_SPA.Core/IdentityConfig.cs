using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using NHSDP_SPA.Core.Model;


namespace VironIT_Social_network_server.WEB.Identity
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext() { }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne<Student>(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>()
                .HasOne<Internship>(e => e.Internship)
                .WithMany(i => i.Enrollments)
                .HasForeignKey(e => e.InternshipId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.InternshipId, e.StudentId })
                .IsUnique();
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}