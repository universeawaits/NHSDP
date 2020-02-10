using AutoMapper;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;


namespace NHSDP_SPA.WEB.Controllers
{
    public class StudyingPlaceController : CRUDControllerBase<StudyingPlace, StudyingPlaceVM>
    {
        public StudyingPlaceController(IMapper mapper, ICRUDServiceBase<StudyingPlace> courseService, 
            ICRUDServiceBase<Office> officeService, ICRUDServiceBase<Internship> internshipService)
        {
            this.mapper = mapper;
            this.entityService = courseService;
        }
    }
}
