using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace NHSDP_SPA.Logic.Implementation
{
    public class CRUDServiceBase<TEntity> : ICRUDServiceBase<TEntity> where TEntity : IEntityBase
    {
        private IUnitOfWork<InternshipContext> uow;

        public CRUDServiceBase(IUnitOfWork<InternshipContext> uow)
        {
            this.uow = uow;
        }

        public async Task<Error> CreateAsync(TEntity entity)
        {
            await uow.Context.Set<TEntity>().AddAsync(entity);

            try
            {
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                return new Error() { Message = ex.GetInnerMessage() };
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

        public async Task<Error> UpdateAsync(TEntity entity)
        {
            uow.Context.Set<TEntity>().Update(entity);

            try
            {
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                return new Error() { Message = ex.GetInnerMessage() };
            }

            return null;
        }
    }
}
