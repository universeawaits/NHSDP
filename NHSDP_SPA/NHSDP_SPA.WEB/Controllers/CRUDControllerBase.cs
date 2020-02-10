using AutoMapper;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace NHSDP_SPA.WEB.Controllers
{
    public abstract class CRUDControllerBase<TEntityCore, TEntityVM> : ApiController where TEntityCore : EntityBase where TEntityVM : EntityBaseVM
    {
        protected ICRUDServiceBase<TEntityCore> entityService;
        protected IMapper mapper;

        [HttpGet]
        public virtual async Task<IEnumerable<TEntityVM>> Get()
        {
            IEnumerable<TEntityCore> entities = await entityService.GetAllAsync();
            return mapper.Map<IEnumerable<TEntityVM>>(entities);
        }

        [HttpGet]
        public virtual async Task<TEntityVM> Get(Guid? id)
        {
            return mapper.Map<TEntityVM>(entityService.Get(id.Value));
        }

        [HttpPut]
        public virtual async Task<ErrorVM> Update(TEntityVM entity)
        {
            Error error = await entityService.UpdateAsync(mapper.Map<TEntityCore>(entity));

            return error == null ? null : mapper.Map<ErrorVM>(error);
        }

        [HttpPost]
        public virtual async Task<ErrorVM> Create(TEntityVM entity)
        {
            Error error = await entityService.CreateAsync(mapper.Map<TEntityCore>(entity));

            return error == null ? null : mapper.Map<ErrorVM>(error);
        }

        [HttpDelete]
        public virtual async Task<ErrorVM> Delete(Guid? id)
        {
            if (id == null)
            {
                return new ErrorVM() { Message = "ID was null" };
            }
            else
            {
                bool isDeleted = await entityService.DeleteAsync(id.Value);

                if (!isDeleted)
                {
                    return new ErrorVM() { Message = typeof(TEntityCore) + " with the ID given was not found" };
                }
            }

            return null;
        }
    }
}
