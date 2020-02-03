using System;


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
}
