﻿using System;
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
    public class OfficeController : Controller
    {
        private readonly ICRUDServiceBase<Office> officeService;
        private readonly ILogger<OfficeController> logger;
        private readonly IMapper mapper;

        public OfficeController(ILogger<OfficeController> logger, IMapper mapper, ICRUDServiceBase<Office> officeService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Office> offices = await officeService.GetAllAsync();
            return View(offices);
        }

        public async Task<IActionResult> UpdateOfficeView(OfficeVM office)
        {
            
            return View();
        }

        public async Task<IActionResult> Update(OfficeVM office)
        {

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        public async Task<IActionResult> Create(OfficeVM office)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActionResultState"] = false;
                ViewData["ActionResultMessage"] = "Enter valid data";
            }
            else
            {
                await officeService.CreateAsync(mapper.Map<Office>(office));
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                ViewData["ActionResultState"] = false;
                ViewData["ActionResultMessage"] = "ID was null";
            }
            else
            {
                bool isDeleted = await officeService.DeleteAsync(id.Value);

                ViewData["ActionResultState"] = isDeleted;
                ViewData["ActionResultMessage"] = isDeleted ? "Office was deleted successfully" : "Office with ID given was not found";
            }

            return RedirectToAction("Index");
        }
    }
}