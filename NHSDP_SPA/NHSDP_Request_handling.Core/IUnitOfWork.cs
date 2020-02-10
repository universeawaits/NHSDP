using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;


namespace NHSDP_SPA.Core
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }

        Task CommitAsync();
    }
}
