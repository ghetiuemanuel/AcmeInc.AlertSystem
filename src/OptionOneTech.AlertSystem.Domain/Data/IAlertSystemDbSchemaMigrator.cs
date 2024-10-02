using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Data;

public interface IAlertSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
