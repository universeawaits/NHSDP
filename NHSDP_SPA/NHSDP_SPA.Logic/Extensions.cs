using System;


namespace NHSDP_SPA.Logic
{
    public static class Extensions
    {
        public static string GetInnerMessage(this Exception ex)
        {
            return ex.InnerException == null ? ex.Message : GetInnerMessage(ex.InnerException);
        }
    }
}
