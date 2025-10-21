using Microsoft.Extensions.Localization;
using VietLife.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace VietLife;

[Dependency(ReplaceServices = true)]
public class VietLifeBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<VietLifeResource> _localizer;

    public VietLifeBrandingProvider(IStringLocalizer<VietLifeResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
