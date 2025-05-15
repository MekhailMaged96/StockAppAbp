using OrderingService.Samples;
using Xunit;

namespace OrderingService.EntityFrameworkCore.Domains;

[Collection(OrderingServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OrderingServiceEntityFrameworkCoreTestModule>
{

}
