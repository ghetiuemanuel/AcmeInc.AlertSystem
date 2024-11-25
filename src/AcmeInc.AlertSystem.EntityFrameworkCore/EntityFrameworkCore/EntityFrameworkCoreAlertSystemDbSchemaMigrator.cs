using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcmeInc.AlertSystem.Data;
using Volo.Abp.DependencyInjection;

namespace AcmeInc.AlertSystem.EntityFrameworkCore;

public class EntityFrameworkCoreAlertSystemDbSchemaMigrator
    : IAlertSystemDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAlertSystemDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AlertSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AlertSystemDbContext>()
            .Database
            .MigrateAsync();
    }
}
