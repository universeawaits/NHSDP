using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.Filters;
using NHSDP_Request_handling.WEB.ViewModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.WEB.Controllers
{
    [ExceptionGuard]
    public abstract class CRUDControllerBase<TEntityCore, TEntityVM> : Controller where TEntityCore : EntityBase where TEntityVM : EntityBaseVM
    {
        protected ICRUDServiceBase<TEntityCore> entityService;
        protected IMapper mapper;

        public virtual async Task<IActionResult> Index()
        {
            IEnumerable<TEntityCore> entities = await entityService.GetAllAsync();
            return View(mapper.Map<IEnumerable<TEntityVM>>(entities));
        }

        public virtual async Task<IActionResult> UpdateView(TEntityVM entity)
        {
            return View(entity);
        }

        public virtual async Task<IActionResult> Update(TEntityVM entity)
        {
            TempData["Message"] = await entityService.UpdateAsync(mapper.Map<TEntityCore>(entity));

            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }

            return View("UpdateView", entity);
        }

        public virtual async Task<IActionResult> CreateView()
        {
            return View();
        }

        public virtual async Task<IActionResult> Create(TEntityVM entity)
        {
            TempData["Message"] = await entityService.CreateAsync(mapper.Map<TEntityCore>(entity));
            
            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }

            return View("CreateView", entity);
        }

        public virtual async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                TempData["Message"] = "ID was null";
            }
            else
            {
                bool isDeleted = await entityService.DeleteAsync(id.Value);

                if (!isDeleted)
                {
                    TempData["Message"] = "Entity with ID given was not found";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
