using Volo.Abp.Settings;

namespace InventoryService.Settings;

public class InventoryServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(InventoryServiceSettings.MySetting1));
    }
}
