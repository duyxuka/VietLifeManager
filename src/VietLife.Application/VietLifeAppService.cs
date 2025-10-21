using VietLife.Localization;
using Volo.Abp.Application.Services;

namespace VietLife;

/* Inherit your application services from this class.
 */
public abstract class VietLifeAppService : ApplicationService
{
    protected VietLifeAppService()
    {
        LocalizationResource = typeof(VietLifeResource);
    }
}
