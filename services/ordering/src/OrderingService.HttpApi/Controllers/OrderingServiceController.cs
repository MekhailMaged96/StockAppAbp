using OrderingService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OrderingService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OrderingServiceController : AbpControllerBase
{
    protected OrderingServiceController()
    {
        LocalizationResource = typeof(OrderingServiceResource);
    }
}
