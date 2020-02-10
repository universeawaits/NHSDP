using AutoMapper;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;


namespace NHSDP_SPA.WEB.Controllers
{
    public class InternshipController : CRUDControllerBase<Internship, InternshipVM>
    {
        public InternshipController(IMapper mapper, ICRUDServiceBase<Internship> internshipService)
        {
            this.mapper = mapper;
            this.entityService = internshipService;
        }
    }
}
