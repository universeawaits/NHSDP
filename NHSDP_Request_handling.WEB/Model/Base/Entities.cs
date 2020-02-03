using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHSDP_Request_handling.WEB.Model.Base
{
    public enum EnrollmentState { InProgress, Stopped, Paused }

    public class Internship : EntityBase
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int MaxStudentsCount { get; set; }
        public int StudentsCount { get; set; }
        public string EnrollmentState { get; set; }
    }

    public class Course : EntityBase
    {
        public string Technology { get; set; }
        public int HoursCount { get; set; }
    }

    public class Program : EntityBase
    {
        public Guid InternshipId { get; set; }
        public Guid CourseId { get; set; }
    }

    public class Office : EntityBase
    {
        public string Adress { get; set; }
        public string CabinetsCount { get; set; }
    }

    public class StydingPlace : EntityBase
    {
        public Guid InternshipId { get; set; }
        public Guid OfficeId { get; set; }
    }
}
