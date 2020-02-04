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
    public class OfficeController : Controller
    {
        private readonly ICRUDServiceBase<Office> officeSerivice;
        private readonly ILogger<OfficeController> logger;
        private readonly IMapper mapper;

        public OfficeController(ILogger<OfficeController> logger, IMapper mapper, ICRUDServiceBase<Office> officeSerivice)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.officeSerivice = officeSerivice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Office> offices = await officeSerivice.GetAllAsync();
            return View(offices);
        }

        [ActionName("update")]
        public async Task<IActionResult> UpdateOffice(Guid? id)
        {
            
            return View();
        }

        [ActionName("create")]
        public async Task<IActionResult> CreateOffice(OfficeVM office)
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOffice(Guid? id)
        {

            return RedirectToAction("");
        }
    }
}
