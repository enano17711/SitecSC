using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.SaleDtos;
using SitecSC.Presentation.ActionFilters;
using Swashbuckle.AspNetCore.Annotations;

namespace SitecSC.Presentation.Controllers;

[Route("api/sale")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public SaleController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    

    [HttpGet("{id:guid}",
        Name = "GetSaleById")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> GetSaleById(Guid id)
    {
        var sale = await _serviceManager.SaleService.GetSaleByIdAsync(id,
            false);
        return Ok(sale);
    }
    

    
    [HttpPost(Name = "CreateSale")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [SwaggerOperation(Summary = "Create sale", OperationId = "CreateSale", Tags = new[] { "Sale" }, Description = "Create sale.")]
    [SwaggerResponse(201, "Created", typeof(SaleDto))]
    [SwaggerResponse(400, "Bad request")]
    [SwaggerResponse(404, "Not found")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreateSale([FromBody] SaleForCreationDto saleDto)
    {
        var sale = await _serviceManager.SaleService.CreateSaleAsync(saleDto);
        return CreatedAtRoute("GetSaleById", new { id = sale.Id }, sale);
    }
}