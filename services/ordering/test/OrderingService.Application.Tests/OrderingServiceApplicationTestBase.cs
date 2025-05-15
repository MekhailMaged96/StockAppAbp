using Volo.Abp.Modularity;

namespace OrderingService;

public abstract class OrderingServiceApplicationTestBase<TStartupModule> : OrderingServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
