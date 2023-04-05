namespace Shared.DataTransferObjects.MovementDtos;

public record MovementDto
{
    public Guid Id { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public Guid ProductId { get; init; }
    public string? PurchaseId { get; init; }
    public string? SaleId { get; init; }
}