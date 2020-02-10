using Microsoft.EntityFrameworkCore;

using NHSDP_SPA.Core.Model;

using System;


namespace NHSDP_SPA.Core
{
    public class InternshipContext : DbContext
    {
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<StudyingPlace> StudyingPlaces { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public InternshipContext() { }

        public InternshipContext(DbContextOptions<InternshipContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Program>()
                .HasOne<Internship>(p => p.Internship)
                .WithMany(i => i.Programs)
                .HasForeignKey(p => p.InternshipId)
                .OnDelete(DeleteBehavior.Cascade);  
            modelBuilder.Entity<Program>()
                .HasOne<Course>(p => p.Course)
                .WithMany(c => c.Programs)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudyingPlace>()
                .HasOne<Internship>(sp => sp.Internship)
                .WithMany(i => i.StudyingPlaces)
                .HasForeignKey(sp => sp.InternshipId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudyingPlace>()
                .HasOne<Office>(sp => sp.Office)
                .WithMany(o => o.StudyingPlaces)
                .HasForeignKey(sp => sp.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasIndex(c => new { c.Technology, c.HoursCount })
                .IsUnique();

            modelBuilder.Entity<Program>()
                .HasIndex(p => new { p.InternshipId, p.CourseId })
                .IsUnique();

            modelBuilder.Entity<StudyingPlace>()
                .HasIndex(sp => new { sp.InternshipId, sp.OfficeId })
                .IsUnique();

            modelBuilder.Entity<Internship>().HasQueryFilter(i => DateTime.Compare(i.StartAt, i.EndAt) < 0);
        }
    }
}
