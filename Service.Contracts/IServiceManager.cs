namespace Service.Contracts;

public interface IServiceManager
{
    IProductService ProductService { get; }
    ISaleService SaleService { get; }
    IPurchaseService PurchaseService { get; }
}