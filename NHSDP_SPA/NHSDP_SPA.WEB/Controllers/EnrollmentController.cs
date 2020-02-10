using AutoMapper;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;


namespace NHSDP_SPA.WEB.Controllers
{
    public class EnrollmentController : CRUDControllerBase<Enrollment, EnrollmentVM>
    {
        public EnrollmentController(IMapper mapper, ICRUDServiceBase<Enrollment> enrollmentService)
        {
            this.mapper = mapper;
            this.entityService = enrollmentService;
        }
    }
}
