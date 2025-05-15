using AutoMapper;
using InventoryService.Products;

namespace InventoryService;

public class InventoryServiceApplicationAutoMapperProfile : Profile
{
    public InventoryServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
