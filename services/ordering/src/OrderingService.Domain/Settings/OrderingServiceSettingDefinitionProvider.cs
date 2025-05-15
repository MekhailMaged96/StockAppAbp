using Volo.Abp.Settings;

namespace OrderingService.Settings;

public class OrderingServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OrderingServiceSettings.MySetting1));
    }
}
