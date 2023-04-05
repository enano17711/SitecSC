using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<ISaleService> _saleService;
    private readonly Lazy<IPurchaseService> _purchaseService;

    public ServiceManager(IRepositoryManager repositoryManager,
        ILoggerManager loggerManager,
        IMapper mapper)
    {
        _productService = new Lazy<IProductService>(() => new ProductService(loggerManager,
            mapper,
            repositoryManager));
        _saleService = new Lazy<ISaleService>(() => new SaleService(repositoryManager,
            mapper,
            loggerManager));
        _purchaseService = new Lazy<IPurchaseService>(() => new PurchaseService(repositoryManager,
            mapper,
            loggerManager));
    }

    public IPurchaseService PurchaseService =>
        _purchaseService.Value;

    public ISaleService SaleService =>
        _saleService.Value;

    public IProductService ProductService =>
        _productService.Value;
}