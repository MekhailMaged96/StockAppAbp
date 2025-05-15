using InventoryService.Samples;
using Xunit;

namespace InventoryService.EntityFrameworkCore.Domains;

[Collection(InventoryServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<InventoryServiceEntityFrameworkCoreTestModule>
{

}
