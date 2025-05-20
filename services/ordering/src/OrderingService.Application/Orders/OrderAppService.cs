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
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace OrderingService.Orders
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IRabbitMqDistributedEventBus _eventBus;
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly ILogger<OrderAppService> _logger;

        public OrderAppService(IRabbitMqDistributedEventBus eventBus, IRepository<Order, Guid> orderRepository,ILogger<OrderAppService> logger )
        {
            _eventBus = eventBus;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<List<OrderDto>> GetListAsync()
        {
            var orders = await _orderRepository.GetListAsync();

            return ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);
        }
        public async Task<Guid> CreateAsync(CreateOrderDto orderDto)
        {
            _logger.LogInformation("Start creating order for ProductId: {ProductId}, Quantity: {Quantity}",
                orderDto.ProductId, orderDto.Quantity);

            var order = new Order(Guid.NewGuid(), orderDto.ProductId, orderDto.ProductName,
                orderDto.Quantity, orderDto.Price);
            await _orderRepository.InsertAsync(order);
        
            _logger.LogInformation("Order inserted with ID: {OrderId}", order.Id);

            var orderEvent = ObjectMapper.Map<Order, OrderCreatedIntegrationEto>(order);
            orderEvent.OrderId = order.Id;

            _logger.LogInformation("Publishing OrderCreatedIntegrationEto to RabbitMQ for OrderId: {OrderId} and  ProductId: {ProductId}", order.Id,orderDto.ProductId);
         
            await _eventBus.PublishAsync(orderEvent);

            _logger.LogInformation("Order creation process completed successfully for OrderId: {OrderId} and ProductId {ProductId}", order.Id,orderDto.ProductId);
       
           return await Task.FromResult(order.Id);
        }

     
    }
}
