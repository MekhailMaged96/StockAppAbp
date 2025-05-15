using InventoryService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace InventoryService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(InventoryServiceEntityFrameworkCoreModule),
    typeof(InventoryServiceApplicationContractsModule)
)]
public class InventoryServiceDbMigratorModule : AbpModule
{
}
