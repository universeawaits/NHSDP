using Microsoft.AspNetCore.Identity;


namespace NHSDP_SPA.Auth.Models
{
    public class Student : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
