using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OrderingService.Orders
{
    public interface IOrderAppService : IApplicationService
    {
       public Task<Guid> AddOrderAsync(CreateOrderDto orderDto);
    }
}
