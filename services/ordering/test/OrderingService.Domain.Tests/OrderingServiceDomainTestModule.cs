using Volo.Abp.Modularity;

namespace OrderingService;

[DependsOn(
    typeof(OrderingServiceDomainModule),
    typeof(OrderingServiceTestBaseModule)
)]
public class OrderingServiceDomainTestModule : AbpModule
{

}
