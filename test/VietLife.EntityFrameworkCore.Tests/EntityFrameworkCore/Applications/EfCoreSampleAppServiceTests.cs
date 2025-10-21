using VietLife.Samples;
using Xunit;

namespace VietLife.EntityFrameworkCore.Applications;

[Collection(VietLifeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<VietLifeEntityFrameworkCoreTestModule>
{

}
