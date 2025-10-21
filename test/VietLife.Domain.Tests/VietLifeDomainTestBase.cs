using Volo.Abp.Modularity;

namespace VietLife;

/* Inherit from this class for your domain layer tests. */
public abstract class VietLifeDomainTestBase<TStartupModule> : VietLifeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
