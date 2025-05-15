using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryService.Products;
using StockAppAbp.Shared.Hosting.Messages.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;

namespace InventoryService.Handlers
{
    public class OrderCreatedHandler : IDistributedEventHandler<OrderCreatedIntegrationEto>, ITransientDependency
    {
        private readonly IProductService _productService;

        public OrderCreatedHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task HandleEventAsync(OrderCreatedIntegrationEto eventData)
        {
            try
            {
                await _productService.ReleaseAsync(eventData.ProductId, eventData.Quantity);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
