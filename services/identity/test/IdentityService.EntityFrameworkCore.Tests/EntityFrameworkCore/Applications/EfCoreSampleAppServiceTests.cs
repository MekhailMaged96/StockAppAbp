using IdentityService.Samples;
using Xunit;

namespace IdentityService.EntityFrameworkCore.Applications;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}
