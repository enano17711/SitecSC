using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.MovementDtos;
using Shared.DataTransferObjects.SaleDtos;

namespace Service;

public class SaleService : ISaleService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;


    public SaleService(IRepositoryManager repository,
        IMapper mapper,
        ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<SaleDto> GetSaleByIdAsync(Guid id,
        bool trackChanges)
    {
        var sale = await _repository.Sale.GetSaleAsync(id,
            trackChanges);
        return _mapper.Map<SaleDto>(sale);
    }

    public async Task<SaleDto> CreateSaleAsync(SaleForCreationDto saleDto)
    {
        foreach (var movement in saleDto.Movements!)
        {
            await ValidateModelAsync(movement);
            movement.Price += (movement.Price * 0.13m);
        }

        var saleEntity = _mapper.Map<Sale>(saleDto);
        saleEntity.SaleTotal = saleDto.Movements.Sum(m => (m.Price * m.Quantity));

        _repository.Sale.CreateSale(saleEntity);
        await _repository.SaveAsync();

        return _mapper.Map<SaleDto>(saleEntity);
    }

    public async Task ValidateModelAsync(MovementForCreationDto movement)
    {
        var product = await _repository.Product.GetProductAsync(new Guid(movement.ProductId!),
            false);

        if (product == null)
            throw new ProductNotFoundException(new Guid(movement.ProductId!));

        var stock = await _repository.Movement.StockProducts(new Guid(movement.ProductId!),
            false);

        if (stock < movement.Quantity || stock < 0)
            throw new MovementStockNotFoundException(new Guid(movement.ProductId!));
    }
}