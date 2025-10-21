using Volo.Abp.Settings;

namespace VietLife.Settings;

public class VietLifeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VietLifeSettings.MySetting1));
    }
}
