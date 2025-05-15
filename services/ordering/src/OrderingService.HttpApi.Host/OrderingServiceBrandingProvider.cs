using Microsoft.Extensions.Localization;
using OrderingService.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OrderingService;

[Dependency(ReplaceServices = true)]
public class OrderingServiceBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OrderingServiceResource> _localizer;

    public OrderingServiceBrandingProvider(IStringLocalizer<OrderingServiceResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
