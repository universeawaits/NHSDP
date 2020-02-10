using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHSDP_SPA.WEB.Controllers
{
    public class OfficeController : CRUDControllerBase<Office, OfficeVM>
    {
        public OfficeController(IMapper mapper, ICRUDServiceBase<Office> officeController)
        {
            this.mapper = mapper;
            this.entityService = officeController;
        }
    }
}
