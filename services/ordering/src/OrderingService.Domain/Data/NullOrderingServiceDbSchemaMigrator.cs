using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OrderingService.Data;

/* This is used if database provider does't define
 * IOrderingServiceDbSchemaMigrator implementation.
 */
public class NullOrderingServiceDbSchemaMigrator : IOrderingServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
