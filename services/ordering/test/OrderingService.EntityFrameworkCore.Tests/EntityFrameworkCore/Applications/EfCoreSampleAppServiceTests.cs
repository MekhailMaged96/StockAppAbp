using OrderingService.Samples;
using Xunit;

namespace OrderingService.EntityFrameworkCore.Applications;

[Collection(OrderingServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OrderingServiceEntityFrameworkCoreTestModule>
{

}
