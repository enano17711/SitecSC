using Entities.Models;

namespace Contracts;

public interface ISaleRepository
{
    Task<Sale?> GetSaleAsync(Guid saleId, bool trackChanges);
    void CreateSale(Sale sale);
}