using System.Threading.Tasks;

namespace OrderingService.Data;

public interface IOrderingServiceDbSchemaMigrator
{
    Task MigrateAsync();
}
