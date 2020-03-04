using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System.Reflection;


namespace NHSDP_SPA.Auth.Data
{
    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=2560;Database=NHSDP;Username=postgres;Password=opend00r",
                sql => sql.MigrationsAssembly(typeof(PersistedGrantDbContextFactory).GetTypeInfo().Assembly.GetName().Name));
            return new PersistedGrantDbContext(optionsBuilder.Options, new OperationalStoreOptions());
        }
    }
}
