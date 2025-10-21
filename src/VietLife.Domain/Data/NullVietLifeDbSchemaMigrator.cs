using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VietLife.Data;

/* This is used if database provider does't define
 * IVietLifeDbSchemaMigrator implementation.
 */
public class NullVietLifeDbSchemaMigrator : IVietLifeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
