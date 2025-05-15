using Volo.Abp.Modularity;

namespace InventoryService;

/* Inherit from this class for your domain layer tests. */
public abstract class InventoryServiceDomainTestBase<TStartupModule> : InventoryServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
