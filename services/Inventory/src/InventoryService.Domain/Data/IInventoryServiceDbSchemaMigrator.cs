using System.Threading.Tasks;

namespace InventoryService.Data;

public interface IInventoryServiceDbSchemaMigrator
{
    Task MigrateAsync();
}
