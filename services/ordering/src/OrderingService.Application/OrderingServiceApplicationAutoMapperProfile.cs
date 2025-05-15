using AutoMapper;
using OrderingService.Orders;
using StockAppAbp.Shared.Hosting.Messages.Events;

namespace OrderingService;

public class OrderingServiceApplicationAutoMapperProfile : Profile
{
    public OrderingServiceApplicationAutoMapperProfile()
    {
        CreateMap<Order, OrderCreatedIntegrationEto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
