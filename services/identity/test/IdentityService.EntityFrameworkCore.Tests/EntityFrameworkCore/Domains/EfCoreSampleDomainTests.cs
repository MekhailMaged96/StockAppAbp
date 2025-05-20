using IdentityService.Samples;
using Xunit;

namespace IdentityService.EntityFrameworkCore.Domains;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}
