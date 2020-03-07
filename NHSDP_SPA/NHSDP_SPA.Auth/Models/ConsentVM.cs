using System.Collections.Generic;


namespace NHSDP_SPA.Auth.Models
{
    public class ConsentVM : ConsentInputModel
    {
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public bool AllowRememberConsent { get; set; }
        public IEnumerable<ScopeVM> IdentityScopes { get; set; }
        public IEnumerable<ScopeVM> ResourceScopes { get; set; }
    }
}
