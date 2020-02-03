using Microsoft.EntityFrameworkCore;

using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.WEB.Model.Base;


namespace NHSDP_Request_handling.Core
{
    public class InternshipContext : DbContext
    {
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<StudyingPlace> StudyingPlaces { get; set; }

        public InternshipContext()
        {
        }

        public InternshipContext(DbContextOptions<InternshipContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
