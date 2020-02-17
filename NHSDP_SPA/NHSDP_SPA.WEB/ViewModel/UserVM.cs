using Microsoft.AspNetCore.Identity;
using NHSDP_SPA.WEB.ViewModel;
using System;


namespace NHSDP_SPA.Core.Model
{
    public class UserVM : EntityBaseVM
    {
        public string Pgone { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Registered { get; set; }
    }
}
