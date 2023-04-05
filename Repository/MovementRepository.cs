using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class MovementRepository : RepositoryBase<Movement>,
    IMovementRepository
{
    public MovementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateMovement(Guid producId,
        Guid purchaseId,
        Guid saleId,
        Movement movement)
    {
        movement.ProductId = producId;
        movement.PurchaseId = purchaseId;
        movement.SaleId = saleId;
        Create(movement);
    }

    public async Task<int?> StockProducts(Guid? productId,
        bool trackChanges)
    {
        var inputs = await FindByCondition(m => m.ProductId == productId && m.SaleId == null,
                trackChanges)
            .SumAsync(m => m.Quantity);

        var outputs = await FindByCondition(m => m.ProductId == productId && m.SaleId != null,
                trackChanges)
            .SumAsync(m => m.Quantity);

        return inputs - outputs;
    }
}