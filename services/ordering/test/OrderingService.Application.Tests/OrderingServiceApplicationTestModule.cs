using Volo.Abp.Modularity;

namespace OrderingService;

[DependsOn(
    typeof(OrderingServiceApplicationModule),
    typeof(OrderingServiceDomainTestModule)
)]
public class OrderingServiceApplicationTestModule : AbpModule
{

}
