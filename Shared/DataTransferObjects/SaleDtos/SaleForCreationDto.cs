using Shared.DataTransferObjects.MovementDtos;

namespace Shared.DataTransferObjects.SaleDtos;

public record SaleForCreationDto : SaleForManipulationDto
{
    public IEnumerable<MovementForCreationDto>? Movements { get; init; }
}