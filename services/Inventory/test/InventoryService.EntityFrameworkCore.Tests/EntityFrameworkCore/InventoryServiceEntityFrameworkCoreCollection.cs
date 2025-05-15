using Xunit;

namespace InventoryService.EntityFrameworkCore;

[CollectionDefinition(InventoryServiceTestConsts.CollectionDefinitionName)]
public class InventoryServiceEntityFrameworkCoreCollection : ICollectionFixture<InventoryServiceEntityFrameworkCoreFixture>
{

}
