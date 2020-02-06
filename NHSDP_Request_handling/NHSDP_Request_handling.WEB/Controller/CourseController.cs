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
    public class CourseController : Controller
    {
        private readonly ICRUDServiceBase<Course> courseService;
        private readonly ILogger<CourseController> logger;
        private readonly IMapper mapper;

        public CourseController(ILogger<CourseController> logger, IMapper mapper, ICRUDServiceBase<Course> internshipService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.courseService = internshipService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await courseService.GetAllAsync();
            return View(mapper.Map<IEnumerable<CourseVM>>(courses));
        }

        public async Task<IActionResult> UpdateView(CourseVM course)
        {
            return View(course);
        }

        public async Task<IActionResult> Update(CourseVM course)
        {
            await courseService.UpdateAsync(mapper.Map<Course>(course));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        public async Task<IActionResult> Create(CourseVM course)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActionResultMessage"] = "Enter valid data";
            }
            else
            {
                await courseService.CreateAsync(mapper.Map<Course>(course));
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
                bool isDeleted = await courseService.DeleteAsync(id.Value);

                if (!isDeleted)
                {
                    ViewData["ActionResultMessage"] = "Internship with ID given was not found";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
