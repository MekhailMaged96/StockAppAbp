using InventoryService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace InventoryService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class InventoryServiceController : AbpControllerBase
{
    protected InventoryServiceController()
    {
        LocalizationResource = typeof(InventoryServiceResource);
    }
}
