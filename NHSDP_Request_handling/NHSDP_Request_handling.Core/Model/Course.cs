using System.Collections.Generic;


namespace NHSDP_Request_handling.Core.Model
{
    public class Course : EntityBase
    {
        public string Technology { get; set; }
        public int HoursCount { get; set; }

        public ICollection<Program> Programs { get; set; }
    }
}
