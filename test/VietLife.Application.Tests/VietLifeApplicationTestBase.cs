using Volo.Abp.Modularity;

namespace VietLife;

public abstract class VietLifeApplicationTestBase<TStartupModule> : VietLifeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
