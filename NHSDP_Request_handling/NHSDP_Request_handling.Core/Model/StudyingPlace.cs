using System;


namespace NHSDP_Request_handling.Core.Model
{
    public class StudyingPlace : EntityBase
    {
        public Guid InternshipId { get; set; }
        public Guid OfficeId { get; set; }

        public Internship Internship { get; set; }
        public Office Office { get; set; }
    }
}
