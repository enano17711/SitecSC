using Shared.DataTransferObjects.SaleDtos;

namespace Service.Contracts;

public interface ISaleService
{
    Task<SaleDto> GetSaleByIdAsync(Guid id, bool trackChanges);
    Task<SaleDto> CreateSaleAsync(SaleForCreationDto saleDto);
}