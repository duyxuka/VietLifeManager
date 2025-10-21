using Volo.Abp.Modularity;

namespace VietLife;

[DependsOn(
    typeof(VietLifeApplicationModule),
    typeof(VietLifeDomainTestModule)
)]
public class VietLifeApplicationTestModule : AbpModule
{

}
