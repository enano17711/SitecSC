using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SaleRepository : RepositoryBase<Sale>,
    ISaleRepository
{
    public SaleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<Sale?> GetSaleAsync(Guid saleId,
        bool trackChanges) =>
        await FindByCondition(s => s.Id.Equals(saleId),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateSale(Sale sale) =>
        Create(sale);
}