using System;
using System.Collections.Generic;


namespace NHSDP_SPA.Core.Model
{
    public class Internship : EntityBase
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int MaxStudentsCount { get; set; }
        public int StudentsCount { get; set; }
        public string EnrollmentState { get; set; }

        public ICollection<Program> Programs { get; set; }
        public ICollection<StudyingPlace> StudyingPlaces { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
