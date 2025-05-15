using OrderingService.Localization;
using Volo.Abp.Application.Services;

namespace OrderingService;

/* Inherit your application services from this class.
 */
public abstract class OrderingServiceAppService : ApplicationService
{
    protected OrderingServiceAppService()
    {
        LocalizationResource = typeof(OrderingServiceResource);
    }
}
