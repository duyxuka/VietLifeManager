using Xunit;

namespace VietLife.EntityFrameworkCore;

[CollectionDefinition(VietLifeTestConsts.CollectionDefinitionName)]
public class VietLifeEntityFrameworkCoreCollection : ICollectionFixture<VietLifeEntityFrameworkCoreFixture>
{

}
