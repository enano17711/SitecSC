using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.MovementDtos;
using Shared.DataTransferObjects.ProductDtos;
using Shared.DataTransferObjects.PurchaseDtos;
using Shared.DataTransferObjects.SaleDtos;

namespace SitecSC;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductForUpdateDto, Product>().ReverseMap();
        CreateMap<ProductForCreationDto, Product>();

        CreateMap<Movement, MovementDto>();
        CreateMap<MovementForCreationDto, Movement>();
        
        CreateMap<Sale, SaleDto>();
        CreateMap<SaleForCreationDto, Sale>();
        
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<PurchaseForCreationDto, Purchase>();
    }
}