using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace InventoryService.Products
{
    public interface IProductService :IApplicationService
    {
        Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        
        Task<ProductDto> GetAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateUpdateProductDto input);
        Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);
        Task DeleteAsync(Guid id);

        Task ReserveAsync(Guid productId, int quantity);
        Task ReleaseAsync(Guid productId, int quantity);
        Task ReplenishAsync(Guid productId, int quantity);
    }
}
