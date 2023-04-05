using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.PurchaseDtos;
using SitecSC.Presentation.ActionFilters;
using Swashbuckle.AspNetCore.Annotations;

namespace SitecSC.Presentation.Controllers;

[Route("api/purchase")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PurchaseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    
    
    [HttpGet("{id:guid}",
        Name = "GetPurchaseById")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> GetPurchaseById(Guid id)
    {
        var purchase = await _serviceManager.PurchaseService.GetPurchaseByIdAsync(id,
            false);
        return Ok(purchase);
    }
    
    

    [HttpPost(Name = "CreatePurchase")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [SwaggerOperation(Summary = "Create purchase", OperationId = "CreatePurchase", Tags = new[] { "Purchase" }, Description = "Create purchase.")]
    [SwaggerResponse(201, "Created", typeof(PurchaseDto))]
    [SwaggerResponse(400, "Bad request")]
    [SwaggerResponse(404, "Not found")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreatePurchase([FromBody] PurchaseForCreationDto purchaseDto)
    {
        var purchase = await _serviceManager.PurchaseService.CreatePurchaseAsync(purchaseDto);
        return CreatedAtRoute("GetPurchaseById", new { id = purchase.Id }, purchase);
    }
}