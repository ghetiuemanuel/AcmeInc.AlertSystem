using System.Threading.Tasks;

namespace AcmeInc.AlertSystem.Data;

public interface IAlertSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
