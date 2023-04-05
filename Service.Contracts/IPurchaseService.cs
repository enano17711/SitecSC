using Shared.DataTransferObjects.PurchaseDtos;

namespace Service.Contracts;

public interface IPurchaseService
{
    Task<PurchaseDto> GetPurchaseByIdAsync(Guid id, bool trackChanges);
    Task<PurchaseDto> CreatePurchaseAsync(PurchaseForCreationDto purchaseDto);
}