using VietLife.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VietLife.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VietLifeController : AbpControllerBase
{
    protected VietLifeController()
    {
        LocalizationResource = typeof(VietLifeResource);
    }
}
