using System;


namespace NHSDP_Request_handling.WEB.ViewModel
{
    public class InternshipVM : EntityBaseVM
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int MaxStudentsCount { get; set; }
        public int StudentsCount { get; set; }
        public string EnrollmentState { get; set; } = "InProgress";
    }
}
