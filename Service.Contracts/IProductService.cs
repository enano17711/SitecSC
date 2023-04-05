using Entities.Models;
using Shared.DataTransferObjects.ProductDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IProductService
{
    Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetProductsAsync(ProductParameters parameters,
        bool trackChanges);

    Task<ProductDto> GetProductByIdAsync(Guid id, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
    Task DeleteProductAsync(Guid id, bool trackChanges);
    Task UpdateProductAsync(Guid id, ProductForUpdateDto product, bool trackChanges);
    Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid id,
        bool trackChanges);

    Task SaveChangesForPatchAsync(ProductForUpdateDto productToPatch, Product productEntity);
}