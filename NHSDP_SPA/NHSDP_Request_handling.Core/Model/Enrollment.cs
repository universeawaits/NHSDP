using System;


namespace NHSDP_SPA.Core.Model
{
    public class Enrollment : EntityBase
    {
        public string StudentId { get; set; }
        public Guid InternshipId { get; set; }
        public string State { get; set; }

        public Student Student { get; set; }
        public Internship Internship { get; set; }
    }
}
