using NHSDP_Request_handling.Core;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.Core.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<string> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> ee = await uow.Context.Set<TEntity>().AddAsync(entity);

            try
            {
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            TEntity found = uow.Context.Set<TEntity>().IgnoreQueryFilters().First(e => e.Id == id);
            
            if (found == null)
            {
                return false;
            }
            else
            {
                uow.Context.Set<TEntity>().Remove(found);
                await uow.CommitAsync();

                return true;
            }
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await uow.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return uow.Context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(Func<TEntity, bool> filterFunc)
        {
            return uow.Context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().Where(filterFunc);
        }

        public async Task<string> UpdateAsync(TEntity entity)
        {
            uow.Context.Set<TEntity>().Update(entity);

            try
            {
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return null;
        }
    }
}
