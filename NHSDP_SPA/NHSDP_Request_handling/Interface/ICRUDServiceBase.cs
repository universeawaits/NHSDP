using NHSDP_SPA.Core.Model;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NHSDP_SPA.Logic.Interface
{
    public interface ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        Task<Error> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<Error> UpdateAsync(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByFilter(Func<TEntity, bool> filterFunc);
    }
}
