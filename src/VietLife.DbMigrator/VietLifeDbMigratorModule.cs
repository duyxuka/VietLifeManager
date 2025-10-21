using VietLife.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VietLife.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VietLifeEntityFrameworkCoreModule),
    typeof(VietLifeApplicationContractsModule)
)]
public class VietLifeDbMigratorModule : AbpModule
{
}
