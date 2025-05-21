using AutoMapper.Internal.Mappers;
using InventoryService.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using JetBrains.Annotations;

public class ProductService : ApplicationService, IProductService
{
    private readonly IRepository<Product, Guid> _repository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IRepository<Product, Guid> repository, ILogger<ProductService> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        _logger.LogInformation("Fetching paged product list");

        // Total count for pagination
        var totalCount = await _repository.GetCountAsync();

        // Get paged products
        var products = await _repository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting ?? nameof(Product.Name) // default sorting
        );

        return new PagedResultDto<ProductDto>(
            totalCount,
            ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
        );
    }
    public async Task<List<ProductDto>> GetAllProducts()
    {

        var products = await _repository.GetListAsync();

        return ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        _logger.LogInformation("Fetching product with ID: {ProductId}", id);
        var product = await _repository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        _logger.LogInformation("Creating product: {ProductName}", input.Name);
        var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
        await _repository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
    {
        _logger.LogInformation("Updating product with ID: {ProductId}", id);
        var product = await _repository.GetAsync(id);
        product.Name = input.Name;
        product.Quantity = input.Quantity;
        await _repository.UpdateAsync(product);
        await CurrentUnitOfWork.SaveChangesAsync();
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInformation("Deleting product with ID: {ProductId}", id);
        await _repository.DeleteAsync(id);
        await CurrentUnitOfWork.SaveChangesAsync();
    }

    public async Task ReserveAsync(Guid productId, int quantity)
    {
        _logger.LogInformation("Reserving {Quantity} of product {ProductId}", quantity, productId);

        var product = await _repository.GetAsync(productId);
        if (product.Quantity < quantity)
        {
            _logger.LogWarning("Insufficient stock for product {ProductId}. Available: {Available}, Requested: {Requested}",
                productId, product.Quantity, quantity);

            throw new BusinessException("Inventory:InsufficientStock")
                .WithData("ProductId", productId);
        }

        product.Quantity -= quantity;
        await _repository.UpdateAsync(product);
        await CurrentUnitOfWork.SaveChangesAsync();
        _logger.LogInformation("Reserved successfully. New quantity: {Quantity} for product {ProductId}", product.Quantity,product.Id);
    }

    public async Task ReleaseAsync(Guid productId, int quantity)
    {
        _logger.LogInformation("Releasing {Quantity} of product {ProductId}", quantity, productId);
        var product = await _repository.GetAsync(productId);
        product.Quantity += quantity;
        await _repository.UpdateAsync(product);
        await CurrentUnitOfWork.SaveChangesAsync();
        _logger.LogInformation("Released successfully. New quantity: {Quantity}", product.Quantity);
    }

    public async Task ReplenishAsync(Guid productId, int quantity)
    {
        _logger.LogInformation("Replenishing {Quantity} of product {ProductId}", quantity, productId);
        var product = await _repository.GetAsync(productId);
        product.Quantity += quantity;
        await _repository.UpdateAsync(product);
        await CurrentUnitOfWork.SaveChangesAsync();
        _logger.LogInformation("Replenished successfully. New quantity: {Quantity}", product.Quantity);
    }

   
}
