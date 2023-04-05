using Shared.DataTransferObjects.MovementDtos;

namespace Shared.DataTransferObjects.SaleDtos;

public record SaleDto
{
    public Guid Id { get; init; }
    public DateTime SaleDate { get; init; }
    public decimal SaleTotal { get; init; }
    public IEnumerable<MovementDto>? Movements { get; init; }
}