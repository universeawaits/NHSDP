using NHSDP_Request_handling.WEB.Model.Base;
using System;


namespace NHSDP_Request_handling.Core.Model
{
    public class StudyingPlace : EntityBase
    {
        public Guid InternshipId { get; set; }
        public Guid OfficeId { get; set; }
    }
}
