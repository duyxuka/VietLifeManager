using System.Threading.Tasks;

namespace VietLife.Data;

public interface IVietLifeDbSchemaMigrator
{
    Task MigrateAsync();
}
