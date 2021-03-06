﻿using NHSDP_Request_handling.Core.Model;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.Logic.Interface
{
    public interface ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        Task<string> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<string> UpdateAsync(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByFilter(Func<TEntity, bool> filterFunc);
    }
}
