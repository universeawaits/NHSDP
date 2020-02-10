using System.Collections.Generic;


namespace NHSDP_SPA.Core.Model
{
    public class Student : User
    {
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
