using Microsoft.Extensions.Localization;
using IdentityService.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace IdentityService;

[Dependency(ReplaceServices = true)]
public class IdentityServiceBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<IdentityServiceResource> _localizer;

    public IdentityServiceBrandingProvider(IStringLocalizer<IdentityServiceResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
