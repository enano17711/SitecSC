using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.PurchaseDtos;

namespace Service;

public class PurchaseService : IPurchaseService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    
    public PurchaseService(IRepositoryManager repository,
        IMapper mapper,
        ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<PurchaseDto> GetPurchaseByIdAsync(Guid id, bool trackChanges)
    {
        var purchase = await _repository.Purchase.GetPurchaseAsync(id,
            trackChanges);
        return _mapper.Map<PurchaseDto>(purchase);
    }

    public async Task<PurchaseDto> CreatePurchaseAsync(PurchaseForCreationDto purchaseDto)
    {
        foreach (var movement in purchaseDto.Movements!)
        {
            var product = await _repository.Product.GetProductAsync(new Guid(movement.ProductId!),
                false);
            
            if (product == null)
                throw new ProductNotFoundException(new Guid(movement.ProductId!));
        }

        var purchaseEntity = _mapper.Map<Purchase>(purchaseDto);
        purchaseEntity.PurchaseTotal = purchaseDto.Movements.Sum(m => m.Price);
        
        _repository.Purchase.CreatePurchase(purchaseEntity);
        await _repository.SaveAsync();
        
        return _mapper.Map<PurchaseDto>(purchaseEntity);
    }
}