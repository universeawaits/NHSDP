using NHSDP_Request_handling.WEB.Model.Base;


namespace NHSDP_Request_handling.Core.Model
{
    public class Course : EntityBase
    {
        public string Technology { get; set; }
        public int HoursCount { get; set; }
    }
}
