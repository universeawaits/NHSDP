using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHSDP_Request_handling.WEB.Controllers
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
