﻿using Microsoft.EntityFrameworkCore;
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
        private IUnitOfWork<DbContext> uow;

        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
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
