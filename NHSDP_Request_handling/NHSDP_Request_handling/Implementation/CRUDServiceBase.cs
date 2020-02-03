using Microsoft.EntityFrameworkCore;
using NHSDP_Request_handling.Core;
using NHSDP_Request_handling.WEB.Model.Base;
using NHSDP_Request_handling.WEB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHSDP_Request_handling.WEB.Service.Implementation
{
    public class CRUDServiceBase<TEntity> : ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        private IUnitOfWork<InternshipContext> uow;

        public CRUDServiceBase(IUnitOfWork<InternshipContext> uow)
        {
            this.uow = uow;
        }

        public Task Create(TEntity entity)
        {
            
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetByFilter(Func<TEntity, bool> filterFunc)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
