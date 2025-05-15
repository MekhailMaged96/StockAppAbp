using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace InventoryService.Data;

/* This is used if database provider does't define
 * IInventoryServiceDbSchemaMigrator implementation.
 */
public class NullInventoryServiceDbSchemaMigrator : IInventoryServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
