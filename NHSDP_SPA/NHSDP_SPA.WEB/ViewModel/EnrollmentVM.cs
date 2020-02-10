using System;


namespace NHSDP_SPA.WEB.ViewModel
{
    public class EnrollmentVM : EntityBaseVM
    {
        public string StudentId { get; set; }
        public Guid InternshipId { get; set; }
        public string State { get; set; }
    }
}
