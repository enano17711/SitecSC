using Entities.Models;

namespace Contracts;

public interface IMovementRepository
{
    void CreateMovement(Guid producId, Guid purchaseId, Guid saleId, Movement movement);
    Task<int?> StockProducts(Guid? productId, bool trackChanges);
}