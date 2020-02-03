using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHSDP_Request_handling.WEB.ViewModel;

namespace NHSDP_Request_handling.WEB.Controllers
{
    public class OfficeController : Controller
    {
        private readonly ILogger<OfficeController> logger;
        private readonly IMapper mapper;

        public OfficeController(ILogger<OfficeController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateOffice()
        {
            return View();
        }

        public async Task<IActionResult> CreateOffice(OfficeVM office)
        {
            return View();
        }

        public async Task<IActionResult> DeleteOffice(int? id)
        {

        }
    }
}
