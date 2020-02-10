using Microsoft.AspNetCore.Identity;

using System;


namespace NHSDP_SPA.Core.Model
{
    public class User : IdentityUser
    {
        public DateTime Registered { get; set; }
    }
}
