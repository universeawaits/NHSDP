using NHSDP_Request_handling.Core;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.Core.Model;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.Logic.Implementation
{
    public class CRUDServiceBase<TEntity> : ICRUDServiceBase<TEntity> where TEntity : EntityBase
    {
        private IUnitOfWork<InternshipContext> uow;

        public CRUDServiceBase(IUnitOfWork<InternshipContext> uow)
        {
            this.uow = uow;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await uow.Context.Set<TEntity>().AddAsync(entity);
            await uow.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            TEntity found = await uow.Context.Set<TEntity>().FindAsync(id);
            uow.Context.Set<TEntity>().Remove(found);
            await uow.CommitAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await uow.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return uow.Context.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(Func<TEntity, bool> filterFunc)
        {
            return uow.Context.Set<TEntity>().AsNoTracking().Where(filterFunc);
        }

        public async Task Update(TEntity entity)
        {
            uow.Context.Set<TEntity>().Update(entity);
            await uow.CommitAsync();
        }
    }
}
