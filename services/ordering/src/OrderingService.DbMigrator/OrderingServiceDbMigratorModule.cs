using OrderingService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OrderingService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OrderingServiceEntityFrameworkCoreModule),
    typeof(OrderingServiceApplicationContractsModule)
)]
public class OrderingServiceDbMigratorModule : AbpModule
{
}
