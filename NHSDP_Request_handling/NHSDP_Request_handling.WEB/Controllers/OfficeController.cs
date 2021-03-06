﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHSDP_Request_handling.WEB.Controllers
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
