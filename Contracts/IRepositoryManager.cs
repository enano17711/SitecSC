namespace Contracts;

public interface IRepositoryManager
{
    IProductRepository Product { get; }
    IMovementRepository Movement { get; }
    ISaleRepository Sale { get; }
    IPurchaseRepository Purchase { get; }
    Task SaveAsync();
}