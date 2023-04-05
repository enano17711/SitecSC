using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.ProductDtos;
using Shared.RequestFeatures;

namespace Service;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ProductService(ILoggerManager logger,
        IMapper mapper,
        IRepositoryManager repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetProductsAsync(
        ProductParameters parameters,
        bool trackChanges)
    {
        var productsWithMetaData = await _repository.Product.GetAllProductsAsync(parameters,
            trackChanges);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
        
        foreach (var product in productsDto)
        {
            var stock = await _repository.Movement.StockProducts(product.Id, trackChanges);
            product.Quantity = stock;
        }

        return (productsDto, productsWithMetaData.MetaData);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid id,
        bool trackChanges)
    {
        var productEntity = await _repository.Product.GetProductAsync(id, trackChanges);
        var productDto = _mapper.Map<ProductDto>(productEntity);
        productDto.Quantity = await _repository.Movement.StockProducts(id, trackChanges);
        return productDto;
    }

    public async Task<ProductDto> CreateProductAsync(ProductForCreationDto product)
    {
        var productEntity = _mapper.Map<Product>(product);
        _repository.Product.CreateProduct(productEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task DeleteProductAsync(Guid id,
        bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(id, trackChanges);
        _repository.Product.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    public async Task UpdateProductAsync(Guid id,
        ProductForUpdateDto product,
        bool trackChanges)
    {
        var productEntity = await GetProductAndCheckIfItExists(id, trackChanges);
        _mapper.Map(product, productEntity);
        await _repository.SaveAsync();
    }

    public async Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid id, bool trackChanges)
    {
        var productEntity = await GetProductAndCheckIfItExists(id, trackChanges);
        var productToPatch = _mapper.Map<ProductForUpdateDto>(productEntity);
        return (productToPatch, productEntity);
    }

    public async Task SaveChangesForPatchAsync(ProductForUpdateDto productToPatch, Product productEntity)
    {
        _mapper.Map(productToPatch, productEntity);
        await _repository.SaveAsync();
    }

    private async Task<Product> GetProductAndCheckIfItExists(Guid id,
        bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(id,
            trackChanges);
        if (product is null)
            throw new ProductNotFoundException(id);
        return product;
    }
}