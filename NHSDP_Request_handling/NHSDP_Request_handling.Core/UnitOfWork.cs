using NHSDP_Request_handling.WEB.Service;

using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.Core
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private TContext context;

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
