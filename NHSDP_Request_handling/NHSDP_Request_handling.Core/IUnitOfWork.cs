﻿using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;


namespace NHSDP_Request_handling.Core
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }

        Task CommitAsync();
    }
}
