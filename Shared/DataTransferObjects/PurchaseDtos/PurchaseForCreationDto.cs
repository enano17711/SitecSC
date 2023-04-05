using Shared.DataTransferObjects.MovementDtos;

namespace Shared.DataTransferObjects.PurchaseDtos;

public record PurchaseForCreationDto : PurchaseForManipulationDto
{
    public IEnumerable<MovementForCreationDto>? Movements { get; init; }
}