using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryService.Products;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrderCreatedHandler> _logger;

        public OrderCreatedHandler(IProductService productService, ILogger<OrderCreatedHandler> logger)
        {
            _productService = productService;
           _logger = logger;
        }
        public async Task HandleEventAsync(OrderCreatedIntegrationEto eventData)
        {
            try
            {
                _logger.LogInformation("Received OrderCreatedIntegrationEto for ProductId: {ProductId}, " +
                    "Quantity: {Quantity}",
                       eventData.ProductId, eventData.Quantity);

                await _productService.ReserveAsync(eventData.ProductId, eventData.Quantity);
                _logger.LogInformation("Reserve operation completed for ProductId: {ProductId}", eventData.ProductId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling OrderCreatedIntegrationEto for ProductId: {ProductId}", eventData.ProductId);

            }
        }
    }
}
