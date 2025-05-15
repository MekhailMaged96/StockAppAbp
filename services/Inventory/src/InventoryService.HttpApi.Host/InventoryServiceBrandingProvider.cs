using Microsoft.Extensions.Localization;
using InventoryService.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace InventoryService;

[Dependency(ReplaceServices = true)]
public class InventoryServiceBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<InventoryServiceResource> _localizer;

    public InventoryServiceBrandingProvider(IStringLocalizer<InventoryServiceResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
