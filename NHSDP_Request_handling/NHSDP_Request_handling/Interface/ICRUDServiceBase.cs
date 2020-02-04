using NHSDP_Request_handling.Core.Model;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.Logic.Interface
{
    public interface ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task Update(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByFilter(Func<TEntity, bool> filterFunc);
    }
}
