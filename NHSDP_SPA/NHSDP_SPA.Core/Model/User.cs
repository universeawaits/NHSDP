using Microsoft.AspNetCore.Identity;

using System;


namespace NHSDP_SPA.Core.Model
{
    public class User : EntityBase
    {
        public DateTime Registered { get; set; }
    }
}
