using Volo.Abp.Modularity;

namespace InventoryService;

public abstract class InventoryServiceApplicationTestBase<TStartupModule> : InventoryServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
