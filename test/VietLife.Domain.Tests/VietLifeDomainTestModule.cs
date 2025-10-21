using Volo.Abp.Modularity;

namespace VietLife;

[DependsOn(
    typeof(VietLifeDomainModule),
    typeof(VietLifeTestBaseModule)
)]
public class VietLifeDomainTestModule : AbpModule
{

}
