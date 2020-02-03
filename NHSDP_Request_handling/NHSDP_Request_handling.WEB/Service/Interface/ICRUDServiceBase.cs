using NHSDP_Request_handling.WEB.Model.Base;
using System;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.WEB.Service.Interface
{
    public interface ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        Task Create(TEntity entity);
        Task Delete(Guid id);
        Task Update(TEntity entity);
        Task Get(Guid id);
        Task GetAll();
        Task GetByFilter(Func<TEntity, bool> filterFunc);
    }
}
