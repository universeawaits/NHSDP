using NHSDP_Request_handling.WEB.Model.Base;


namespace NHSDP_Request_handling.Core.Model
{
    public class Office : EntityBase
    {
        public string Adress { get; set; }
        public int CabinetsCount { get; set; }
    }
}
