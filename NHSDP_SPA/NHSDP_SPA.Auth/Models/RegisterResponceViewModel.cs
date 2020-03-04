using NHSDP_SPA.Auth.Data;


namespace NHSDP_SPA.Auth.Models
{
    public class RegisterResponseVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public RegisterResponseVM(AppUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
        }
    }
}
