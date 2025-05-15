using InventoryService.Localization;
using Volo.Abp.Application.Services;

namespace InventoryService;

/* Inherit your application services from this class.
 */
public abstract class InventoryServiceAppService : ApplicationService
{
    protected InventoryServiceAppService()
    {
        LocalizationResource = typeof(InventoryServiceResource);
    }
}
