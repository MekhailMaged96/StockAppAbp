using Volo.Abp.Modularity;

namespace OrderingService;

/* Inherit from this class for your domain layer tests. */
public abstract class OrderingServiceDomainTestBase<TStartupModule> : OrderingServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
