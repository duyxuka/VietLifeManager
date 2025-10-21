using VietLife.Samples;
using Xunit;

namespace VietLife.EntityFrameworkCore.Domains;

[Collection(VietLifeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<VietLifeEntityFrameworkCoreTestModule>
{

}
