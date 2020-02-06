using AutoMapper;

using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.ViewModel;


namespace NHSDP_Request_handling.WEB.Controllers
{
    public class CourseController : CRUDControllerBase<Course, CourseVM>
    {
        public CourseController(IMapper mapper, ICRUDServiceBase<Course> courseService)
        {
            this.mapper = mapper;
            this.entityService = courseService;
        }
    }
}
