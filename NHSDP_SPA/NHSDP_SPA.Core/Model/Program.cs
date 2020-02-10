using System;


namespace NHSDP_SPA.Core.Model
{
    public class Program : EntityBase
    {
        public Guid InternshipId { get; set; }
        public Guid CourseId { get; set; }

        public Internship Internship { get; set; }
        public Course Course { get; set; }
    }
}
