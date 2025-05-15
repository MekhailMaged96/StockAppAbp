using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using OrderingService.Orders;
using StockAppAbp.Shared.Hosting.Messages.Events;
using Volo.Abp.EventBus.Distributed;
using JetBrains.Annotations;
using Volo.Abp.ObjectMapping;
using Volo.Abp.EventBus.RabbitMq;

namespace OrderingService.Orders
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IRabbitMqDistributedEventBus _eventBus;
        private readonly IRepository<Order, Guid> _orderRepository;

        public OrderAppService(IRabbitMqDistributedEventBus eventBus, IRepository<Order, Guid> orderRepository)
        {
            _eventBus = eventBus;
            _orderRepository = orderRepository;
        }

        
        public async Task CreateOrderAsync(CreateOrderDto orderDto)
        {
            var order = new Order(Guid.NewGuid(), orderDto.ProductId, orderDto.ProductName, orderDto.Quantity, orderDto.Price);
            await _orderRepository.InsertAsync(order);

            var orderEvent = ObjectMapper.Map<Order, OrderCreatedIntegrationEto>(order);

            orderEvent.OrderId = order.Id;
          
            await _eventBus.PublishAsync(orderEvent); // Publish event to RabbitMQ
        }
    }
}
