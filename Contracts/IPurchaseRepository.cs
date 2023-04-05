using Entities.Models;

namespace Contracts;

public interface IPurchaseRepository
{
    Task<Purchase?> GetPurchaseAsync(Guid purchaseId, bool trackChanges);
    void CreatePurchase(Purchase purchase);
}