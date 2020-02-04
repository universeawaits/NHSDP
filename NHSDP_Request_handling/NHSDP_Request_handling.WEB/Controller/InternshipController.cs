using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.ViewModel;


namespace NHSDP_Request_handling.WEB.Controllers
{
    public class InternshipController : Controller
    {
        private readonly ICRUDServiceBase<Internship> internshipService;
        private readonly ILogger<InternshipController> logger;
        private readonly IMapper mapper;

        public InternshipController(ILogger<InternshipController> logger, IMapper mapper, ICRUDServiceBase<Internship> internshipService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.internshipService = internshipService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Internship> offices = await internshipService.GetAllAsync();
            return View(offices);
        }

        [ActionName("update")]
        public async Task<IActionResult> UpdateInternship(Guid? id)
        {
            
            return View();
        }

        [ActionName("create")]
        public async Task<IActionResult> CreateInternship(OfficeVM office)
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInternship(Guid? id)
        {

            return RedirectToAction("");
        }
    }
}
