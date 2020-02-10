using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NHSDP_SPA.WEB.Controllers
{
    public class ProgramController : CRUDControllerBase<Core.Model.Program, ProgramVM>
    {
        private ICRUDServiceBase<Course> officeService;
        private ICRUDServiceBase<Internship> internshipService;

        public ProgramController(IMapper mapper, ICRUDServiceBase<Core.Model.Program> programService, 
            ICRUDServiceBase<Course> officeService, ICRUDServiceBase<Internship> internshipService)
        {
            this.mapper = mapper;
            this.entityService = programService;
            this.officeService = officeService;
            this.internshipService = internshipService;
        }

        public override async Task<IActionResult> CreateView()
        {
            IEnumerable<Course> offices = await officeService.GetAllAsync();
            ViewData["Courses"] = mapper.Map<IEnumerable<CourseVM>>(offices).Select(o =>
                                    new SelectListItem()
                                    {
                                        Text = o.Technology + ", " + o.HoursCount + " hours",
                                        Value = o.Id.ToString()
                                    }).ToList();

            IEnumerable<Internship> internships = await internshipService.GetAllAsync();
            ViewData["Internships"] = mapper.Map<IEnumerable<InternshipVM>>(internships).Select(i =>
                                        new SelectListItem()
                                        {
                                            Text = i.StartAt.Date.ToShortDateString() + "-" + i.EndAt.Date.ToShortDateString() 
                                                + ", " + i.EnrollmentState,
                                            Value = i.Id.ToString(),
                                        }).ToList();

            return await base.CreateView();
        }
    }
}
