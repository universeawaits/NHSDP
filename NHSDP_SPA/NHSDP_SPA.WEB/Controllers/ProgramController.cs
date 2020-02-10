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
        public ProgramController(IMapper mapper, ICRUDServiceBase<Core.Model.Program> programService, 
            ICRUDServiceBase<Course> officeService, ICRUDServiceBase<Internship> internshipService)
        {
            this.mapper = mapper;
            this.entityService = programService;
        }
    }
}
