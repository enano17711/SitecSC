using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class PurchaseRepository : RepositoryBase<Purchase>,
    IPurchaseRepository
{
    public PurchaseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<Purchase?> GetPurchaseAsync(Guid purchaseId,
        bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(purchaseId),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreatePurchase(Purchase purchase) =>
        Create(purchase);
}