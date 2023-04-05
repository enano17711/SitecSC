using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>,
    IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters,
        bool trackChanges)
    {
        var products = await FindAll(trackChanges)
            .Include(p => p.Movements)
            .SearchGeneric(productParameters.SearchColumn,
                productParameters.SearchTerm)
            .SortGeneric(productParameters.SortColumn,
                productParameters.SortOrder)
            .ToListAsync();

        return PagedList<Product>.ToPagedList(products,
            productParameters.PageNumber,
            productParameters.PageSize);
    }

    public async Task<Product?> GetProductAsync(Guid productId,
        bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(productId),
                trackChanges)
            .Include(p => p.Movements)
            .SingleOrDefaultAsync();

    public void CreateProduct(Product product) =>
        Create(product);

    public void DeleteProduct(Product product) =>
        Delete(product);
}