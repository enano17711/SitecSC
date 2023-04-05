using Shared.DataTransferObjects.MovementDtos;

namespace Shared.DataTransferObjects.PurchaseDtos;

public record PurchaseDto
{
    public Guid Id { get; init; }
    public DateTime PurchaseDate { get; init; }
    public decimal PurchaseTotal { get; init; }
    public IEnumerable<MovementDto>? Movements { get; init; }
}