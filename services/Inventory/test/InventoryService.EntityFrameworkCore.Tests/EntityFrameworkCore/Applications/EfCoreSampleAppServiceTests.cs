using InventoryService.Samples;
using Xunit;

namespace InventoryService.EntityFrameworkCore.Applications;

[Collection(InventoryServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<InventoryServiceEntityFrameworkCoreTestModule>
{

}
