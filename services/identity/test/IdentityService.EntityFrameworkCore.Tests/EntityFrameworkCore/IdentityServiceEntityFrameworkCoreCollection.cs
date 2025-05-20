using Xunit;

namespace IdentityService.EntityFrameworkCore;

[CollectionDefinition(IdentityServiceTestConsts.CollectionDefinitionName)]
public class IdentityServiceEntityFrameworkCoreCollection : ICollectionFixture<IdentityServiceEntityFrameworkCoreFixture>
{

}
