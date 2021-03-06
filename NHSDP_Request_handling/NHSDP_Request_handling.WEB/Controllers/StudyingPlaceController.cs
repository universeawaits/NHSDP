﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.ViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.WEB.Controllers
{
    public class StudyingPlaceController : CRUDControllerBase<StudyingPlace, StudyingPlaceVM>
    {
        private ICRUDServiceBase<Office> officeService;
        private ICRUDServiceBase<Internship> internshipService;

        public StudyingPlaceController(IMapper mapper, ICRUDServiceBase<StudyingPlace> courseService, 
            ICRUDServiceBase<Office> officeService, ICRUDServiceBase<Internship> internshipService)
        {
            this.mapper = mapper;
            this.entityService = courseService;
            this.officeService = officeService;
            this.internshipService = internshipService;
        }

        public override async Task<IActionResult> CreateView()
        {
            IEnumerable<Office> offices = await officeService.GetAllAsync();
            ViewData["Offices"] = mapper.Map<IEnumerable<OfficeVM>>(offices).Select(o =>
                                    new SelectListItem()
                                    {
                                        Text = o.Adress,
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

        public override async Task<IActionResult> Create(StudyingPlaceVM sp)
        {
            TempData["Message"] = await entityService.CreateAsync(mapper.Map<StudyingPlace>(sp));

            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateView");
        }
    }
}
