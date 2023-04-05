namespace Entities.Exceptions;

public class MovementStockNotFoundException : NotFoundException
{
    public MovementStockNotFoundException(Guid id) : base($"Not enough stock for product {id}")
    {
    }
}