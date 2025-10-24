using Volo.Abp.Settings;

namespace RuichenShuxin.AbpPro.Settings;

public class AbpProSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpProSettings.MySetting1));
    }
}
