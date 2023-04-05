using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IMovementRepository> _movementRepository;
    private readonly Lazy<ISaleRepository> _saleRepository;
    private readonly Lazy<IPurchaseRepository> _purchaseRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        _movementRepository = new Lazy<IMovementRepository>(() => new MovementRepository(repositoryContext));
        _saleRepository = new Lazy<ISaleRepository>(() => new SaleRepository(repositoryContext));
        _purchaseRepository = new Lazy<IPurchaseRepository>(() => new PurchaseRepository(repositoryContext));
    }
    
    public IPurchaseRepository Purchase =>
        _purchaseRepository.Value;

    public ISaleRepository Sale =>
        _saleRepository.Value;

    public IMovementRepository Movement =>
        _movementRepository.Value;

    public IProductRepository Product =>
        _productRepository.Value;

    public Task SaveAsync() =>
        _repositoryContext.SaveChangesAsync();
}