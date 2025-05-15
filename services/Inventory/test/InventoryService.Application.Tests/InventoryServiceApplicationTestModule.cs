using Volo.Abp.Modularity;

namespace InventoryService;

[DependsOn(
    typeof(InventoryServiceApplicationModule),
    typeof(InventoryServiceDomainTestModule)
)]
public class InventoryServiceApplicationTestModule : AbpModule
{

}
