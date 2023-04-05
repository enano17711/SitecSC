using Shared.DataTransferObjects.MovementDtos;

namespace Shared.DataTransferObjects.ProductDtos;

public record ProductDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? Quantity { get; set; }
    public IEnumerable<MovementDto>? Movements { get; set; }
}