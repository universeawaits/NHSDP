using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<Internship> internships = await internshipService.GetAllAsync();
            return View(internships);
        }

        public async Task<IActionResult> UpdateView(InternshipVM internship)
        {
            return View(internship);
        }

        public async Task<IActionResult> Update(InternshipVM internship)
        {
            await internshipService.UpdateAsync(mapper.Map<Internship>(internship));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        public async Task<IActionResult> Create(InternshipVM internship)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActionResultMessage"] = "Enter valid data";
            }
            else
            {
                await internshipService.CreateAsync(mapper.Map<Internship>(internship));
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                ViewData["ActionResultMessage"] = "ID was null";
            }
            else
            {
                bool isDeleted = await internshipService.DeleteAsync(id.Value);

                if (!isDeleted)
                {
                    ViewData["ActionResultMessage"] = "Internship with ID given was not found";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
