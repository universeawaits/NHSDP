using AutoMapper;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;


namespace NHSDP_SPA.WEB.Controllers
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
