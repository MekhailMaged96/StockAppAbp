using Volo.Abp.Modularity;

namespace InventoryService;

[DependsOn(
    typeof(InventoryServiceDomainModule),
    typeof(InventoryServiceTestBaseModule)
)]
public class InventoryServiceDomainTestModule : AbpModule
{

}
