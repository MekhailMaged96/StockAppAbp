using IdentityService.Localization;
using Volo.Abp.Application.Services;

namespace IdentityService;

/* Inherit your application services from this class.
 */
public abstract class IdentityServiceAppService : ApplicationService
{
    protected IdentityServiceAppService()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}
