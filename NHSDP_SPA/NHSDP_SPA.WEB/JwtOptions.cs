﻿namespace NHSDP_SPA.WEB
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Lifetime { get; set; }
        public string Secret { get; set; }
    }
}
