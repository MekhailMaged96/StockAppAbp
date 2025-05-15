using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace InventoryService.Products
{
    public class ProductService :ApplicationService, IProductService
    {
        private readonly IRepository<Product, Guid> _repository;

        public ProductService(IRepository<Product, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            var products = await _repository.GetListAsync();
            return ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _repository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
            await _repository.InsertAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _repository.GetAsync(id);
            product.Name = input.Name;
            product.Quantity = input.Quantity;
            await _repository.UpdateAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task ReserveAsync(Guid productId, int quantity)
        {
            var product = await _repository.GetAsync(productId);
            if (product.Quantity < quantity)
            {
                throw new BusinessException("Inventory:InsufficientStock")
                    .WithData("ProductId", productId);
            }

            product.Quantity -= quantity;
            await _repository.UpdateAsync(product);
        }

        public async Task ReleaseAsync(Guid productId, int quantity)
        {
            var product = await _repository.GetAsync(productId);
            product.Quantity += quantity;
            await _repository.UpdateAsync(product);
        }

        public async Task ReplenishAsync(Guid productId, int quantity)
        {
            var product = await _repository.GetAsync(productId);
            product.Quantity += quantity;
            await _repository.UpdateAsync(product);
        }
    }
}
