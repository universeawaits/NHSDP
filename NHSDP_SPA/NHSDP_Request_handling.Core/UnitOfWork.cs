using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;


namespace NHSDP_SPA.Core
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            Context = context;
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
