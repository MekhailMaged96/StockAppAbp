using Xunit;

namespace OrderingService.EntityFrameworkCore;

[CollectionDefinition(OrderingServiceTestConsts.CollectionDefinitionName)]
public class OrderingServiceEntityFrameworkCoreCollection : ICollectionFixture<OrderingServiceEntityFrameworkCoreFixture>
{

}
