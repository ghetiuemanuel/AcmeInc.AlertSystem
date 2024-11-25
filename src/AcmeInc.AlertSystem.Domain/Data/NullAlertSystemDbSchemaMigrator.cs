using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AcmeInc.AlertSystem.Data;

/* This is used if database provider does't define
 * IAlertSystemDbSchemaMigrator implementation.
 */
public class NullAlertSystemDbSchemaMigrator : IAlertSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
