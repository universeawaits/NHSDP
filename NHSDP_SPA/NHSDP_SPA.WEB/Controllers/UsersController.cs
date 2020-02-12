using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;


namespace NHSDP_SPA.WEB.Controllers
{
    [Route("my")]
    [ApiController]
    public class UsersController : CRUDControllerBase<Enrollment, EnrollmentVM>
    {
        public UsersController(IMapper mapper, ICRUDServiceBase<Enrollment> enrollmentService)
        {
            this.mapper = mapper;
            this.entityService = enrollmentService;
        }
    }
}
